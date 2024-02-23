using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myApi.Data;
using myApi.Models.Domain;
using myApi.Models.Dto;
namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly DevDbContext dbContext;

        public CommentController(DevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> getAllComment([FromRoute] Guid id)
        {
            var comment = await dbContext.Comments.Where(x => x.ProductId == id).ToListAsync();
            if (comment.Count > 0)
            {
                return Ok(new { statusCode = "200", data = comment });
            }
            return Ok(null);
        }
        [HttpPost]
        public async Task<IActionResult> createComment([FromBody] CommentDto commentDto)
        {
            if (commentDto != null)
            {
                var data = new Comment
                {
                    ProductId = commentDto.ProductId,
                    UserName = commentDto.UserName,
                    evaluate = commentDto.evaluate,
                    Title = commentDto.Title,
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now
                };
                await dbContext.Comments.AddAsync(data);
                await dbContext.SaveChangesAsync();
                return Ok(new { statusCode = "200", message = "Thêm mới thành công!!" });
            }
            return Ok(null);
        }
    }
}