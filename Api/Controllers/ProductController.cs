using Api.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace Api.Controllers
{
    [ApiController]
    [Route("")]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Fullstack Challenge 20201026");
        }

        [HttpGet("/products")]
        public IActionResult GetAllProducts([FromRoute] int pageIndex, [FromRoute] int pageSize)
        {
            return Ok(productRepository.GetAllProducts(pageIndex, pageSize));
        }

        [HttpGet("products/{code}")]
        public IActionResult GetByCode([FromRoute] long code)
        {
            var products = productRepository.GetProductByCode(code);

            if(products is null) return NotFound();

            return Ok(products);
        }
    }
}