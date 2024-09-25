using Ejercicio1_5.MODELOS;
using Ejercicio1_5.NEGOCIO.Servicios;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1_5.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacturaController : ControllerBase
    {
        private readonly IFacturaAplicacion _aplicacion;
        public FacturaController()
        {
            _aplicacion = new FacturaServicio();
        }

        [HttpGet("todas_las_facturas")]
        public IActionResult ObtenerTodos()
        {
            return Ok(_aplicacion.ObtenerTodos());
        }

        [HttpGet("facturas_filtradas")]
        public IActionResult ObtenerTodosConFiltros ([FromQuery]string fechaInicio, [FromQuery] string fechaFin, [FromQuery] int idFormaPago)
        {
            return Ok(_aplicacion.ObtenerTodosConFiltros(fechaInicio, fechaFin, idFormaPago));
        }

        [HttpGet("obtener_factura")]
        public IActionResult ObtenerPorId([FromQuery] int id)
        {
            return Ok(_aplicacion.ObtenerPorId(id));
        }

        [HttpPost("nueva_factura")]
        public IActionResult Nuevo([FromBody] Factura factura)
        {
            var result = _aplicacion.Nuevo(factura);
            return Ok(result);
        }

        [HttpPost("modificar_factura")]
        public IActionResult Modificar([FromBody] Factura factura)
        {
            var result = _aplicacion.Modificar(factura);
            return Ok(result);
        }

        [HttpDelete]
        public IActionResult Eliminar([FromQuery] int id)
        {
            var result = _aplicacion.Eliminar(id);
            return Ok(result);
        }
    }

}

