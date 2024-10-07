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

        //        ++ Modificar el proyecto de tipo librería (DLL) para que exponga las funcionalidades de: registrar,
        //        --consultar (con filtros), editar y registrar la baja de turnos (cancelación).

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

        [HttpPost("Nuevo_Turno")]
        public async Task<IActionResult> Post([FromBody] Turno turno)
        {
            try
            {
                //? La fecha del turno deberá tener como valor por defecto la fecha actual + 1 (fecha día siguiente como mínimo).
                //Deberá controlar que la fecha de reserva no supere los 45 días a la fecha actual. 

                //? Deberá controlar que no se pueden grabar dos veces el mismo servicio como detalle.
                //Es decir, no puede solicitar “corte de cabello” 2 veces en el mismo turno. 

                //? Controlar que se hayan ingresado datos de al menos un servicio. 

                //? Al registrar un turno se deberá retornar objeto mensaje de confirmación. 


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
                // Actualizar los datos de una turno siempre que la fecha/hora sean anteriores a los confirmados en su creación 

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

                // Cancelar una turno indicando un motivo de cancelación. Al igual que 
                //el apartado anterior, validar la restricción temporal.

                // Actualizar el modelo de datos con los campos: fecha_cancelación y 
                //motivo_cancelación en la tabla turnos. 
                return Ok(await _service.DeleteByIdAsync(id));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno");
            }
        }
    }
}
