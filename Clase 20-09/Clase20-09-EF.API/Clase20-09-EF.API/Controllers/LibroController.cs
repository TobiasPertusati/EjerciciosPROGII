using Clase20_09_EF.DLL.Data.Models;
using Clase20_09_EF.DLL.Data.Repositories.Interfaces;
using Clase20_09_EF.DLL.Data.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Clase20_09_EF.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        // GET: api/<LibroController>

        private readonly ILibroRepository _service;

        public LibroController(ILibroRepository service)
        {
            _service =  service;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_service.GetAll());

            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno");
            }
        }

        //// GET api/<LibroController>/5
        //[HttpGet("{id}")]
        //public IActionResult Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<LibroController>
        //[HttpPost]
        //public IActionResult Post([FromBody] string value)
        //{
        //}

        //// PUT api/<LibroController>/5
        //[HttpPut("{id}")]
        //public IActionResult Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<LibroController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                _service.Delete(id);
                return Ok("Libro eliminado");
            }
            catch (Exception)
            {
                return StatusCode(500, "Ocurrio un error interno");
            }

        }
    }
}
