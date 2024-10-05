using EnviosWebApi.Models;
using EnviosWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnviosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EnvioController : ControllerBase
    {
        private readonly IEnvioRepository _repository;
        public EnvioController(IEnvioRepository repository)
        {
            _repository = repository;
        }
        [HttpGet("Listar_Envios_entreFechas")]
        public async Task<IActionResult> GetAll(DateTime fecha1, DateTime fecha2)
        {
            try
            {
                // verifico que las fechas no sea nulas
                if (fecha1.ToString() == "01/01/0001 0:00:00" || fecha2.ToString() == "01/01/0001 0:00:00")
                    return BadRequest("Debe proporcionar ambas fechas");

                List<TEnvio> envios = await _repository.GetAll(fecha1, fecha2);
                if (envios.Count == 0)
                {
                    return NotFound("No se encontraron envios entre las fechas proporcionadas");
                }
                return Ok(envios);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }
        [HttpPost("Nuevo_Envio")]
        public async Task<IActionResult> Create([FromBody] TEnvio envio)
        {
            try
            {
 
                if (string.IsNullOrWhiteSpace(envio.Direccion) || string.IsNullOrWhiteSpace(envio.DniCliente)
                    || string.IsNullOrEmpty(envio.Estado) || envio.FechaEnvio.ToString() == "01/01/0001 0:00:00"
                    || envio.IdEmpresa <= 0)
                {
                    BadRequest("Debe completar todos los campos");
                }
                if (envio.Estado.ToUpper() == "CANCELADO")
                {
                    BadRequest("No se pueden cargar envios cancelados");
                }
                if (envio.FechaEnvio < DateTime.Today)
                {
                    BadRequest("Solo se pueden cargar envios con fecha posterior o igual al dia de hoy");
                }
                if (envio.Direccion.Length > 50 || envio.DniCliente.Length > 50 || envio.Estado.Length > 50)
                {
                    BadRequest("La maxima cantidad de caracteres para los campos dni, direccion y estado es de 50 caracteres");
                }


                return Ok(await _repository.Create(envio));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }
        [HttpPut("modificar_estado")]
        public async Task<IActionResult> UpdateState([FromQuery] int id)
        {
            try
            {
                bool res = await _repository.DeleteLogico(id);
                if (!res)
                    BadRequest("No se encontro ningun envio con esa id, o ya se encuentra cancelado");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }







    }
}
