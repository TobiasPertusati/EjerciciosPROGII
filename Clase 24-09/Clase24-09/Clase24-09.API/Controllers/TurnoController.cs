using Clase24_09.DLL.Entities.Models;
using Clase24_09.DLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Clase24_09.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoService _service;
        public TurnoController(ITurnoService service)
        {
            _service = service;
        }

        [HttpGet("listar_todos_los_turnos")]
        public ActionResult ObtenerTurnos() 
        {
            try
            {
               return Ok(_service.GetAll());
            }
            catch (Exception EX)
            {
                return StatusCode(500, EX.ToString());
            }
        }
        //[HttpGet("obtener_Turno")]
        //public ActionResult ObtenerTurnoPorId([FromQuery] int id)
        //{
        //    try
        //    {
        //        return Ok();
        //    }
        //    catch (Exception)
        //    {
        //        return StatusCode(500, "Error interno.");
        //    }
        //}
        [HttpPost("nuevo_turno")]
        public ActionResult Nuevo([FromBody] Turno turno)
        {
            try
            {
                return Ok(_service.Save(turno));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }
        [HttpPut("modificar_turno")]
        public ActionResult Modificar([FromBody] Turno turno)
        {
            try
            {
                return Ok(_service.Update(turno));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }
        [HttpDelete("eliminar_turno")]
        public ActionResult Eliminar([FromQuery] int id)
        {
            try
            {
                return Ok(_service.Delete(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno.");
            }
        }
    }
}
