using Ejercicio2_7.DLL.Data.Models;
using Ejercicio2_7.DLL.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Collections.Generic;
using System.Text.Json.Serialization;

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

        [JsonConverter(typeof(JsonStringEnumConverter))]
        public enum EstadoTurno
        {
            Todos,
            Pendientes,
            Cancelados
        }
        [HttpGet("Todos_los_turnos")]
        public async Task<IActionResult> GetAllTurnosAsync([FromQuery] EstadoTurno estadoTurno)
        {
            string estado;
            switch (estadoTurno)
            {
                case EstadoTurno.Todos:
                    estado = "Todos";
                    break;
                case EstadoTurno.Pendientes:
                    estado = "Pendientes";
                    break;
                default:
                    estado = "Cancelados";
                    break;
            }
            try
            {
                List<Turno> turnos = await _service.GetAllTurnosASYNC(estado);
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
                //Deberá controlar que la fecha de reserva no supere los 45 días a la fecha actual.  DONE


                if (await _service.ExistByFechaASYNC(turno.Fecha,turno.Hora,turno.Id))
                    return BadRequest("Ya se encuentra un turno registrado con esa fecha y hora");


                DateTime fechaTurno = Convert.ToDateTime(turno.Fecha);
                if (fechaTurno <= DateTime.Today || fechaTurno > DateTime.Today.AddDays(45))
                    return BadRequest("Los turnos solo se pueden reservar para el dia siguiente al actual y en una fecha menor al dia de hoy + 45 dias");

                //? Deberá controlar que no se pueden grabar dos veces el mismo servicio como detalle.  DONE
                //Es decir, no puede solicitar “corte de cabello” 2 veces en el mismo turno.

                var duplicates = turno.TDetallesTurnos
                    .GroupBy(d => d.IdServicio)
                    .Where(d => d.Count() > 1)
                    .Select(d => d.Key);
                if (duplicates.Any())
                    return BadRequest("No puede solicitar más de 1 vez el mismo servicio en un turno");


                //? Controlar que se hayan ingresado datos de al menos un servicio.  DONE
                if (turno.TDetallesTurnos.Count <= 0)
                {
                    return BadRequest("Debe solicitar al menos un servicio en un turno");
                }

                //? Al registrar un turno se deberá retornar objeto mensaje de confirmación.   DONE
                bool res = await _service.CreateAsync(turno);
                if (!res)
                {
                    return StatusCode(500, "No se pudo registrar el turno");
                }
                return Ok("Se registro el turno con exito");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno");
            }
        }

        // PUT api/<TurnoController>/5
        [HttpPut("Modificar_Turno")]
        public async Task<IActionResult> Put([FromBody] Turno t)
        {
            try
            {
                // Actualizar los datos de una turno siempre que la fecha/hora sean anteriores a los confirmados en su creación 
                
                if (await _service.ExistByFechaASYNC(t.Fecha, t.Hora,t.Id))
                    return BadRequest("Ya se encuentra un turno registrado con esa fecha y hora");

                string fecha = DateTime.Now.ToString();
                string hora = DateTime.Now.Hour.ToString();

                bool res = await _service.UpdateASYNC(t, fecha, hora);
                if (!res)
                    return BadRequest("No se puedo actualizar el turno.");

                return Ok("El turno se actualizo con exito");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno");
            }
        }

        [HttpPut("Baja_Logica_Turno")]
        public async Task<IActionResult> Delete(int id,string motivoCancelacion)
        {
            try
            {
                // Cancelar una turno indicando un motivo de cancelación. Al igual que 
                //el apartado anterior, validar la restricción temporal.

                // Actualizar el modelo de datos con los campos: fecha_cancelación y 
                //motivo_cancelación en la tabla turnos. 

                bool res = await _service.DeleteByIdAsync(id, motivoCancelacion);
                if (!res)
                    return BadRequest("No se encontro el turno o ya se encuentra cancelado");

                return Ok("Se cancelo el turno con exito");
            }
            catch (Exception)
            {
                return StatusCode(500, "Error Interno");
            }
        }
    }
}
