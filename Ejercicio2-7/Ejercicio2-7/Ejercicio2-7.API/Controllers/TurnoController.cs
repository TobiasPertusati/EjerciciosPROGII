using Ejercicio2_7.DLL.Data.Models;
using Ejercicio2_7.DLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Ejercicio2_7.API.Controllers
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



        [HttpGet("Todos_los_turnos")]
        public async Task<IActionResult> GetAllTurnosAsync()
        {
            try
            {
                List<Turno> turnos = await _service.GetAllTurnosASYNC();
                if (turnos.Count == 0)
                {
                    return BadRequest("No se encontraron turnos.");
                }
                return Ok(turnos);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno");
            }
        }


        [HttpGet("Obtener_turno")]
        public async Task<IActionResult> GetTurno([FromQuery] int id)
        {
            try
            {
                Turno t = await _service.GetByIdAsync(id);
                if (t == null)
                {
                    return BadRequest("No se encontro un turno con esa id.");
                }
                return Ok(t);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno");
            }
        }

        // POST api/<TurnoController>
        [HttpPost("Nuevo_Turno")]
        public async Task<IActionResult> Post([FromBody] Turno turno)
        {
            try
            {
                // VALIDACIONES

                return Ok(await _service.SaveAsync(turno));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno");
            }
        }

        // PUT api/<TurnoController>/5
        [HttpPut("Modificar_Turno")]
        public async Task<IActionResult> Put([FromBody] Turno turno)
        {
            try
            {
                return Ok(await _service.SaveAsync(turno));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                return Ok(await _service.DeleteByIdAsync(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno");
            }
        }
    }
}
