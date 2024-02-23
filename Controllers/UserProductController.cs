using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myApi.Data;
using myApi.Models.Domain;
using myApi.Models.Dto;
namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserProductController : ControllerBase
    {
        private readonly DevDbContext dbContext;

        public UserProductController(DevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        [Route("{userId:guid}")]
        public async Task<IActionResult> GetProductByUserId([FromRoute] string userId, [FromBody] string type)
        {
            if (Guid.TryParse(userId, out Guid res))
            {
                var userProduct = await dbContext.UserProducts.Where(x => x.UserId == res && x.Type == type).Include("Product").ToListAsync();
                if (userProduct.Count > 0)
                {
                    var products = userProduct.Select(x => x.Product).ToList();
                    if (products.Count > 0)
                    {
                        return Ok(new { statusCode = "200", data = products });
                    }
                }
            }
            return Ok(new { statusCode = "400", message = "Không thể tìm thấy product" });
        }
        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateUserProduct([FromBody] UserPDto userP)
        {
            if (userP != null)
            {
                foreach (Guid id in userP.ProductId)
                {
                    var data = new UserProduct
                    {
                        UserId = Guid.Parse(userP.UserId),
                        ProductId = id
                    };
                    dbContext.UserProducts.Add(data);
                }
                await dbContext.SaveChangesAsync();
                return Ok(new { statusCode = "200", message = "Tạo thành công" });
            }
            return Ok(new { statusCode = "400", message = "Tạo không thành công" });
        }
        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> deleteUserProduct([FromBody] UserProductDto dto)
        {

            if (Guid.TryParse(dto.UserId, out Guid userId) && Guid.TryParse(dto.ProductId, out Guid productId))
            {
                var result = await dbContext.UserProducts.FirstOrDefaultAsync(x => x.UserId == userId && x.ProductId == productId);
                if (result != null)
                {
                    dbContext.Remove(result);
                    await dbContext.SaveChangesAsync();
                    return Ok(new { statusCode = "200", message = "Xóa thành công" });
                }
            }
            return Ok(new { statusCode = "400", message = "Xóa không thành công" });
        }
    }
}