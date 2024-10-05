using Ejercicio2_7.API.Entities;
using Ejercicio2_7.API.Services;
using Ejercicio2_7.API.Services.Aplicaciones;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio2_7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoAplicacion _service;


        public TurnoController()
        {
            _service = new TurnoServices();
        }

        // La fecha de reserva deberá tener como valor por defecto la fecha actual 
        //+ 1 (fecha día siguiente como mínimo). Deberá controlar que la fecha
        //de reserva no supere los 45 días a la fecha actual.
        // Deberá controlar que no se pueden grabar dos veces el mismo servicio
        //como detalle. Es decir, no puede solicitar “corte de cabello” 2 veces en
        //el mismo turno.
        // Deberá controlar además que solo es posible registrar el turno si para
        //la fecha y hora seleccionadas no existe un registro previamente
        //cargado.
        // Controlar que se hayan ingresado datos de al menos un servicio.
        // Al registrar un turno se deberá retornar objeto mensaje de confirmación.
        [HttpGet]
        public IActionResult ContarTurnos(string fecha, string hora)
        {
            return Ok(_service.ContarTurnos(fecha, hora));
        }
        [HttpPost]
        public IActionResult InsertarTurno(Turno turno)
        {
            int year = Convert.ToInt32(turno.Fecha.Substring(6, 4));
            int mes = Convert.ToInt32(turno.Fecha.Substring(0, 2));
            int dia = Convert.ToInt32(turno.Fecha.Substring(3, 2));

            DateTime dias45 = DateTime.Now.AddDays(45);
            DateTime fechaCargada = new(year, mes, dia);
            if (fechaCargada > dias45  || fechaCargada == DateTime.Now)
            {
                return BadRequest("Las reservas deben ser simpre para el un dia posterior al actual " +
                    "y ubicarse dentro de un plazo maximo de 45 dias");
            }
            return Ok(_service.InsertarTurno(turno));
        }

    }
}
