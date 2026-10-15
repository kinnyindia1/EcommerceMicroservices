using Catalog.API.Models;
using Microsoft.AspNetCore.Mvc;


namespace Catalog.API.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new()
    {
        new Product { Id = 1, Name = "Laptop", Price = 999.99m },
        new Product { Id = 2, Name = "Mouse", Price = 25.50m }
    };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get() => Ok(Products);

        [HttpGet("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var product = Products.FirstOrDefault(p => p.Id == id);
            return product == null ? NotFound() : Ok(product);
        }
    }
}
