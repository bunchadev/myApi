using Microsoft.AspNetCore.Mvc;
using myApi.Models.Dto;
using myApi.Repositories;

namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCartController : ControllerBase
    {
        private readonly IUserCartRepository userCartRepository;
        public UserCartController(IUserCartRepository userCartRepository)
        {
            this.userCartRepository = userCartRepository;
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> getCartByUser([FromRoute] string id)
        {
            var products = await userCartRepository.getCartByUser(id);
            if (products.Count > 0)
            {
                return Ok(new { statusCode = "200", data = products });
            }
            return Ok(new { statusCode = "400" });
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> createUserCart([FromBody] UserProductDto dto)
        {
            var result = await userCartRepository.createUserCart(dto);
            return Ok(new { statusCode = result });
        }
        [HttpPost]
        [Route("delete/many")]
        public async Task<IActionResult> deleteManyUserCarts([FromBody] UserPDto userP)
        {
            var result = await userCartRepository.deleteManyUserCarts(userP);
            return Ok(new { statusCode = result });
        }
        [HttpPost]
        [Route("delete/one")]
        public async Task<IActionResult> deleteOneUserCart([FromBody] UserProductDto dto)
        {
            var result = await userCartRepository.deleteOneUserCart(dto);
            return Ok(new { statusCode = result });
        }
    }
}