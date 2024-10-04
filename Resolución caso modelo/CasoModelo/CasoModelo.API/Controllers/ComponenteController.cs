using CasoModelo.DLL.Data.Models;
using CasoModelo.DLL.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CasoModelo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponenteController : ControllerBase
    {
        private readonly IComponenteRepository _repository;
        public ComponenteController(IComponenteRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("obtener_componentes")]
        public IActionResult GetAll()
        {
            try
            {
                List<Componente> componenteList = _repository.GetAll();
                if (componenteList.Count == 0)
                {
                    return BadRequest("No se encontraron componentes");
                }
                return Ok(_repository.GetAll());

            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno");
            }
        }

    }
}
