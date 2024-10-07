using Ejercicio2_7.DLL.Data.Models;
using Ejercicio2_7.DLL.Services;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Serialization;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicio2_7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {

        private readonly IServicioService _service;
        public ServicioController(IServicioService service)
        {
            _service = service;
        }

        //        ++ Crear un segundo proyecto de tipo librería (DLL) que exponga los servicios para:
        //        --registrar, consultar (con filtros), editar y registrar la baja lógica de servicios.

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum Promocion
        {
            Todos,
            EnPromocion,
            SinPromocion,
        }
        [HttpGet("listar_servicios_promocion")]
        public async Task<IActionResult> GetAll([FromQuery] Promocion promocion)
        {
            string valor;
            switch (promocion)
            {
                case Promocion.EnPromocion:
                    valor = "S";
                    break;
                case Promocion.SinPromocion:
                    valor = "N";
                    break;
                default:
                    valor = "";
                    break;
            }
            try
            {
                List<Servicio> servicios = await _service.GetAllASYNC(valor);
                if (servicios.Count == 0)
                {
                    return NotFound("No se econtraron servicios");
                }
                return Ok(servicios);
            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error");
            }
        }
        [HttpPost("Registrar_servicio")]
        public async Task<IActionResult> Create([FromBody] Servicio servicio)
        {
            try
            {
                bool res = await _service.SaveASYNC(servicio);
                return Ok(res);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error");
            }
        }
        [HttpPut("Editar_servicio")]
        public async Task<IActionResult> Update([FromBody] Servicio servicio)
        {
            try
            {
                bool res = await _service.SaveASYNC(servicio);
                return Ok(res);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error");
            }
        }
        [HttpPut("Eliminar_Servicio")]
        public async Task<IActionResult> Delete([FromQuery] int id)
        {
            try
            {
                bool res = await _service.LogicDelete(id);
                return Ok(res);

            }
            catch (Exception)
            {
                return StatusCode(500, "Internal error");
            }
        }
    }
}
