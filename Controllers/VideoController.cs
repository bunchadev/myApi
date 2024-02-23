using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myApi.Data;
using myApi.Models.Dto;
namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly DevDbContext dbContext;

        public VideoController(DevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetVideoByProductId([FromRoute] Guid id)
        {
            var videos = await dbContext.Videos.Where(x => x.ProductId == id)
                                               .Include(x => x.DescriptionVideos)
                                               .ToListAsync();
            if (videos.Count > 0)
            {
                var result = videos.Select(x =>
                     new VideoDto
                     {
                         Title = x.Title,
                         DescriptionVideoDtos = x?.DescriptionVideos?.Select(item =>
                         new DescriptionVideoDto
                         {
                             TitleVideo = item.TitleVideo,
                             TimeVideo = item.TimeVideo
                         }).ToList()
                     }).ToList();
                return Ok(result);
            }
            var message = new Message
            {
                message = "Can not find videos",
                statuscode = 401
            };
            return Ok(message);
        }
    }
}