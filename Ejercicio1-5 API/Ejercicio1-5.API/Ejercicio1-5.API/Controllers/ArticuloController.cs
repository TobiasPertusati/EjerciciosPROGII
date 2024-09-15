using Ejercicio1_5.MODELOS;
using Ejercicio1_5.NEGOCIO.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1_5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticuloController : ControllerBase
    {
        private readonly IAplicacion _aplicacion;
        public ArticuloController()
        {
            _aplicacion = new ArticuloServicio();
        }

        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            return Ok(_aplicacion.ObtenerTodos());
        }

        [HttpGet("{id}")]
        public IActionResult ObtenerPorId(int id)
        {
            return Ok(_aplicacion.ObtenerPorId(id));
        }

        [HttpPost]
        public IActionResult Guardar(Articulo articulo)
        {
            var result = _aplicacion.Guardar(articulo);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Eliminar(int id)
        {
            var result = _aplicacion.Eliminar(id);
            return Ok(result);
        }
    }
}
