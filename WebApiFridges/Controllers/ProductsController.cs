using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiFridges.CLIENT.MyResponceClasses;
using WebApiFridges.MyIntefaces;

namespace WebApiFridges.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductsController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            IEnumerable<ResponceProducts> products = productRepository.GetProducts();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!products.Any())
                return StatusCode(204,ModelState);

            return Ok(products);
        }

        [HttpPut]
        public IActionResult UpdateProduct(Guid productId, string newProductName, int newDefaultQuant)
        {
            if (!productRepository.IsProductExist(productId))
            {
                ModelState.AddModelError("", "The product with this identifier does not exist!");
                return StatusCode(404, ModelState);
            }

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            if (!productRepository.ProductUpdate(productId,newProductName,newDefaultQuant))
            {
                ModelState.AddModelError("", "Something went wrong while saving!");
                return StatusCode(500, ModelState);
            }

            return Ok("Successfully updated!");
        }
    }
}
