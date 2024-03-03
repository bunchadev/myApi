using Microsoft.AspNetCore.Mvc;
using myApi.Dto.Domain;
using myApi.Models.Dto;
using myApi.Repositories;
namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository productRepository;
        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }
        [HttpPost]
        // [JwtAuthorization("admin")]
        public async Task<IActionResult> GetProductWithType([FromBody] CheckType checkType)
        {
            var result = await productRepository.GetProductWithType(checkType);
            if (result.Count > 0)
            {
                return Ok(new { statusCode = "200", data = result });
            }
            return Ok(new { statusCode = "400" });
        }
        [HttpPost]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetProductById([FromRoute] Guid id, [FromBody] string? userId)
        {
            var product = await productRepository.GetProductById(id, userId);
            if (product != null)
            {
                return Ok(product);
            }
            return Ok(product);
        }
        [HttpGet]
        [Route("Search")]
        public async Task<IActionResult> GetProductBySearch([FromQuery] string query, [FromQuery] string? id)
        {
            var result = await productRepository.GetProductBySearch(query, id);
            if (result.Count > 0)
            {
                return Ok(new { statusOk = "200", data = result });
            }
            return Ok(new { statusOk = "400", data = result });
        }
        [HttpPost]
        [Route("one/{id:guid}")]
        public async Task<IActionResult> GetProductByIdUser([FromRoute] Guid id)
        {
            var products = await productRepository.GetProductByIdUser(id);
            if (products.Count > 0)
            {
                return Ok(new { statusCode = "200", data = products });
            }
            return Ok(new { statusCode = "400" });
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateProduct([FromBody] createProduct product)
        {
            var result = await productRepository.CreateProduct(product);
            return Ok(new { statusCode = result });
        }
        [HttpPost]
        [Route("delete/{id:guid}")]
        public async Task<IActionResult> deleteProduct([FromRoute] Guid id)
        {
            var result = await productRepository.deleteProduct(id);
            return Ok(new { statusCode = result });
        }
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> UpLoadFileImage([FromForm] IFormFile file)
        {
            var result = await productRepository.UpLoadFileImage(file);
            return Ok(new { statusCode = result });
        }
    }
}