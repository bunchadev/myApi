using System.Drawing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myApi.Data;
using myApi.Models.Domain;
using myApi.Models.Dto;

namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserCartController : ControllerBase
    {
        private readonly DevDbContext dbContext;

        public UserCartController(DevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> getCartByUser([FromRoute] string id)
        {
            if (Guid.TryParse(id, out Guid res))
            {
                var products = await dbContext.userCarts.Where(x => x.UserId == res).Include("product").ToListAsync();
                if (products.Count > 0)
                {
                    var result = products.Select(x => x.product).ToList();
                    return Ok(new { statusCode = "200", data = result });
                }
            }
            return Ok(new { statusCode = "400" });
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> createUserCart([FromBody] UserProductDto dto)
        {
            if (Guid.TryParse(dto.UserId, out Guid userId) && Guid.TryParse(dto.ProductId, out Guid productId))
            {
                var userCart = new UserCart
                {
                    ProductId = productId,
                    UserId = userId
                };
                await dbContext.userCarts.AddAsync(userCart);
                await dbContext.SaveChangesAsync();
                return Ok(new { statusCode = "200" });
            }
            return Ok(new { statusCode = "400" });
        }
        [HttpPost]
        [Route("delete/many")]
        public async Task<IActionResult> deleteManyUserCarts([FromBody] UserPDto userP)
        {
            if (Guid.TryParse(userP.UserId, out Guid res))
            {
                var users = await dbContext.userCarts.Where(x => userP.ProductId.Contains(x.ProductId) && x.UserId == res).ToListAsync();
                if (users.Count > 0)
                {
                    dbContext.RemoveRange(users);
                    await dbContext.SaveChangesAsync();
                    return Ok(new { statusCode = "200" });
                }
            }
            return Ok(new { statusCode = "400" });
        }
        [HttpPost]
        [Route("delete/one")]
        public async Task<IActionResult> deleteOneUserCart([FromBody] UserProductDto dto)
        {
            if (Guid.TryParse(dto.UserId, out Guid userId) && Guid.TryParse(dto.ProductId, out Guid productId))
            {
                var userCart = await dbContext.userCarts.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
                if (userCart != null)
                {
                    dbContext.userCarts.Remove(userCart);
                    await dbContext.SaveChangesAsync();
                }
                return Ok(new { statusCode = "200" });
            }
            return Ok(new { statusCode = "400" });
        }
    }
}