using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPITest.Models;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly List<Product> products = new List<Product>();


        [HttpGet]
        public IActionResult Get()
        {
            products.Add(new Product() { Codigo = 1, Name = "Mate", Price = 32100 });
            products.Add(new Product() { Codigo = 2, Name = "Yerba", Price = 4100 });
            products.Add(new Product() { Codigo = 1, Name = "Bombilla", Price = 5100 });
            return Ok(products);
        }
    }
}
