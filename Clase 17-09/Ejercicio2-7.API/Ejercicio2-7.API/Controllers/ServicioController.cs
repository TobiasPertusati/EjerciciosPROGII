using Ejercicio2_7.API.Services.Aplicaciones;
using Ejercicio2_7.DATA.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio2_7.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicioController : ControllerBase
    {
        private readonly IServicioAplicacion _service;
        public ServicioController()
        {
            _service = new ServicioService();
        }


        [HttpGet]
        public IActionResult ConsultarServicios()
        {
            return Ok(_service.ConsultarServicios());
        }
    }
}
