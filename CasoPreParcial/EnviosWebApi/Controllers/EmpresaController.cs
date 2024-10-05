using EnviosWebApi.Models;
using EnviosWebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnviosWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {

        private readonly IEmpresaRepository _repository;
        public EmpresaController(IEmpresaRepository repository)
        {
            _repository = repository;
        }

        [HttpGet("listar_empresas_filtro")]
        public async Task<IActionResult> GetAllFiltro()
        {
            try
            {
                List<TEmpresa> empresas = await _repository.GetAll();
                if (empresas.Count == 0)
                    return NotFound("No se econtraron empresas");
                return Ok(empresas);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Error interno :" + ex.ToString());
            }
        }
        [HttpGet("obtener_empresa")]
        public async Task<IActionResult> Get([FromQuery] int id)
        {
            try
            {
                TEmpresa emp = await _repository.Get(id);
                if (emp == null)
                {
                    return BadRequest("No se encontro ninguna empresa con esa id");
                }
                return Ok(emp);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

    }
}
