using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myApi.Data;
using myApi.Models.Dto;
namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonContentController : ControllerBase
    {
        private readonly DevDbContext dbContext;

        public LessonContentController(DevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetLessonContentByProductId([FromRoute] Guid id)
        {
            var lessonContents = await dbContext.LessonContents.Where(x => x.ProductId == id).ToListAsync();
            if (lessonContents.Count > 0)
            {
                var data = new LessonContentDto();
                List<string?> result = lessonContents.Select(x => x.Title).ToList() ?? new List<string?>();
                if (result.Count > 0)
                {
                    data.Title = result;
                    return Ok(data);
                }
            }
            var message = new Message
            {
                message = "can not find lesson content for product",
                statuscode = 401
            };
            return Ok(message);
        }
    }
}