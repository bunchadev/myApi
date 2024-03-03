using Microsoft.AspNetCore.Mvc;
using myApi.Models.Dto;
using myApi.Repositories;
namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProductController : ControllerBase
    {
        private readonly IUserProductRepository userProductRepository;
        public UserProductController(IUserProductRepository userProductRepository)
        {
            this.userProductRepository = userProductRepository;
        }
        [HttpPost]
        [Route("{userId:guid}")]
        public async Task<IActionResult> GetProductByUserId([FromRoute] string userId, [FromBody] string type)
        {
            var result = await userProductRepository.GetProductByUserId(userId, type);
            if (result.Count > 0)
            {
                return Ok(new { statusCode = "200", data = result });
            }
            return Ok(new { statusCode = "400", message = "Không thể tìm thấy product" });
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUserProduct([FromBody] UserPDto userP)
        {
            var result = await userProductRepository.CreateUserProduct(userP);
            return Ok(new { statusCode = result });
        }
        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> deleteUserProduct([FromBody] UserProductDto dto)
        {
            var result = await userProductRepository.deleteUserProduct(dto);
            return Ok(new { statusCode = result });
        }
    }
}