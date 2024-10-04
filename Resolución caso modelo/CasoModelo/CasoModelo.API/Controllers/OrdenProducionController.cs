using CasoModelo.DLL.Data.Models;
using CasoModelo.DLL.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasoModelo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenProducionController : ControllerBase
    {
        private readonly IOrdenRepository _repository;
        public OrdenProducionController(IOrdenRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("obtener_ordenes_filtro")]
        public IActionResult GetAllFiltro([FromQuery] DateTime fechaDesde, [FromQuery] bool estado)
        {
            try
            {
                List<OrdenProducion> oList = _repository.GetAllFiltro(fechaDesde, estado);
                if (oList.Count == 0)
                {
                    return BadRequest("No se encontraron componentes");
                }
                return Ok(oList);

            }
            catch (Exception)
            {
                return StatusCode(500, "internal error");
            }
        }




        [HttpPost("nueva_orden")]
        public IActionResult NuevaOrden([FromBody] OrdenProducion orden)
        {
            try
            {
                // VALIDACIONES
                // El estado inicial de la orden es Creada.                                                         DONE
                // La fecha de la orden no podrá ser nunca anterior a la fecha actual                               DONE
                // Deberá validar los campos obligatorios según la definición de campos de tabla Ordenes_produccion DONE
                // Deberá validar que un mismo componente no puede figurar más de una vez como detalle de receta.   DONE    
                // Deberá validar se hayan ingresado datos de al menos como mínimo 2 componentes.                   DONE
                // Deberá garantizar que la orden de producción siempre se graba completa o no se graba.            DONE

                if (orden.Fecha == null || string.IsNullOrWhiteSpace(orden.Modelo) || orden.Cantidad <= 0)
                {
                    return BadRequest("Debe completar todos los campos");
                }
                if (orden.Modelo.Length > 50)
                {
                    return BadRequest("El nombre del modelo no puede superar los 50 caracteres");
                }
                if (orden.Estado == false)
                {
                    return BadRequest("Solo se pueden cargar ordenes con estado creada");
                }
                if (orden.Fecha < DateTime.Today)
                {
                    return BadRequest("La orden no puede ser nunca una fecha anterior a la actual");
                }
                if (orden.DetallesOrdens.Count < 2)
                {
                    return BadRequest("El modelo debe tener como mínimo dos componentes!");
                }
                else
                {
                    List<int> codigosUtilizados = new List<int>();
                    int cont = 0;
                    bool flag = false;
                    foreach (var d in orden.DetallesOrdens)
                    {
                        if (cont >= 1)
                        {
                            foreach (int cod in codigosUtilizados)
                            {
                                if (d.CodComponente == cod)
                                {
                                    flag = true;
                                    break;
                                }
                            }
                        }
                        if (flag)
                            return BadRequest("El modelo no puede tener 2 detalles con los mismos componentes!");
                        codigosUtilizados.Add((int)d.CodComponente);
                        cont++;
                    }

                }
                return Ok(_repository.AddOrden(orden));
            }
            catch (Exception)
            {
                return StatusCode(500, "internal error");
            }
        }

        [HttpPut("modificar_orden")]
        public IActionResult ModificarOrden([FromQuery] int nroOrden, [FromQuery] DateTime fecha, [FromQuery] int cantidad)
        {
            try
            {
                return Ok(_repository.UpdateOrden(nroOrden, fecha, cantidad));
            }
            catch (Exception)
            {
                return StatusCode(500, "internal error");
            }
        }

        [HttpPut("eliminar_orden")]
        public IActionResult EliminarOrden([FromQuery] int nroOrden)
        {
            try
            {
                // Solo es posible registrar la baja de una orden si su estado es distinto de 
                //Cancelada o Finalizada. 
                bool res = _repository.UpdateEstado(nroOrden);
                if (!res)
                    return BadRequest("La orden ya se encuentra cancelada o no existe");
                return Ok(res);
            }
            catch (Exception)
            {
                return StatusCode(500, "internal error");
            }
        }
    }
}
