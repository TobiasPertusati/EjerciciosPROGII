using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModeloParcial1.DLL.Data.Models;
using ModeloParcial1.DLL.Services;

namespace ModeloParcial1.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeliculasController : ControllerBase
    {
        private readonly IPeliculaService _service;
        public PeliculasController(IPeliculaService service)
        {
            _service = service;
        }

        [HttpGet("peliculas_en_estreno")]
        public async Task<IActionResult> GetPeliculas()
        {
            try
            {
                List<Pelicula> peliculas = await _service.GetAllASYNC();
                if (peliculas == null)
                {
                    return NotFound("No hay peliculas en cartelera");
                }
                return Ok(peliculas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpGet("peliculas_entre_años")]
        public async Task<IActionResult> GetPeliculasAnios([FromQuery] int minYear, [FromQuery] int maxYear)
        {
            try
            {
                List<Pelicula> peliculas = await _service.GetAllBetweenYears(minYear,maxYear);
                return Ok(peliculas);
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpPost("nueva_pelicula")]
        public async Task<IActionResult> CreatePelicula([FromBody] Pelicula pelicula)
        {
            try
            {
                if (pelicula.IdGenero <= 0 | string.IsNullOrWhiteSpace(pelicula.Titulo) | string.IsNullOrWhiteSpace(pelicula.Director) | pelicula.Anio <= 0 )
                      return BadRequest("Se deben completar todos los campos");

                if (pelicula.Titulo.Length > 100)
                    return BadRequest("El titulo de la  pelicula no puede superar los 100 caracteres");

                if (pelicula.Director.Length > 50)
                    return BadRequest("El Nombre del director no puede superar los 50 caracteres");
                
                pelicula.Estreno = true;
                return Ok(await _service.CreateASYNC(pelicula));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpPut("modificar_pelicula")]
        public async Task<IActionResult> UpdatePelicula([FromBody] Pelicula pelicula)
        {
            try
            {
                return Ok(await _service.UpdateASYNC(pelicula));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }

        [HttpPut("eliminar_pelicula")]
        public async Task<IActionResult> EliminarPelicula([FromQuery] int id, [FromQuery] DateOnly fechaBaja, [FromQuery] string motivoBaja)
        {
            try
            {
                return Ok(await _service.DeleteASYNC(id,fechaBaja,motivoBaja));
            }
            catch (Exception)
            {
                return StatusCode(500, "Error interno");
            }
        }
    }
}
