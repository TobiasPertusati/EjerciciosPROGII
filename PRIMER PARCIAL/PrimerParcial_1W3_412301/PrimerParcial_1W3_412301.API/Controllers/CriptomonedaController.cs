using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Win32;
using PrimerParcial_1W3_412301.DLL.Data.Models;
using PrimerParcial_1W3_412301.DLL.Service;
using System.Drawing;

namespace PrimerParcial_1W3_412301.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CriptomonedaController : ControllerBase
    {
        // 412301 PERTUSATI TOBIAS;

        private readonly ICriptomonedaService _service;
        public CriptomonedaController(ICriptomonedaService service)
        {
            _service = service;
        }

        //o GET /cripto | Recupera todas las criptomonedas según las consideraciones
        //indicadas
        //Consultar criptomonedas de una categoría determinada
        //("Plataforma", "Moneda", "Token"), 
        // Solo es posible consultar monedas cuya última actualización no supere un día a la fecha.
        [HttpGet("Obtener_criptomonedas")]
        public async Task<IActionResult> GetAll([FromQuery] int categoria)
        {
            try
            {
                List<Criptomoneda> criptos = await _service.GetAllByCategoria(categoria);
                if (criptos.Count == 0)
                {
                    return NotFound("No se econtraron criptomonedas de esa categoria");
                }
                return Ok(criptos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        //o PUT /cripto? simbolo = ETC; valorActual=20 |Permite actualizar el valor de la moneda a partir del símbolo.
        // actualizar el valor actual(junto con la fecha/hora de la última cotización)
        //de una criptomoneda identificada por símbolo(por ejemplo: BTC para Bitcoins)
        // Al momento de actualizar la cotización de una moneda la fecha/hora de la última cotización no puede ser superior a un día.
        ///Por ejemplo, es posible indicar que el valor de ayer fue de x dólares, pero no el de antes de ayer.
        [HttpPut("Modificar_Cripto")]
        public async Task<IActionResult> Update([FromQuery] string simbolo, [FromQuery] double valorActual, [FromQuery] DateTime fechaActualizacion)
        {
            try
            {
                // VALIDACIONES
                if (simbolo.Length > 10)
                {
                    return BadRequest("El simbolo de la moneda no puede superar los 10 caracteres");
                }
                DateTime yesterday = DateTime.Today.AddDays(-1);
                DateTime tomorrow = DateTime.Today.AddDays(1);
                if (fechaActualizacion < yesterday || fechaActualizacion >= tomorrow)
                {
                    return BadRequest("La fecha de actualizacion solo se puede situar entre ayer y hoy \n" +
                                      "Y debe ser del formato MM/DD/YYYY");
                }
                if (string.IsNullOrWhiteSpace(simbolo) || valorActual <= 0 || fechaActualizacion.ToString() == "01/01/0001 0:00:00")
                {
                    return BadRequest("Debe Completar todos los campos correctamente");
                }

                bool res =  await _service.Update(simbolo,valorActual,fechaActualizacion);
                if (!res)
                    return BadRequest("No se pudo actualizar la criptomoneda");

                return Ok("Se actualizo correctamente el valor de la criptomoneda");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Error");
            }
        }

        //o DELETE /cripto/1: Permite actualizar el estado de la criptomoneda identificada por id.
        // registrar la inhabilitación de una moneda.
        [HttpPut("Eliminar_Cripto")]
        public async Task<IActionResult> LogicDelete([FromQuery] int id)
        {
            try
            {
                bool res = await _service.LogicDelete(id);
                if (!res)
                    return BadRequest("No se encontro ninguna criptomoneda con esa id, o ya esta inhabilitada");

                return Ok("Se inhabilito la criptomoneda correctamente");
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal Error");
            }
        }




    }
}
