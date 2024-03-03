using Microsoft.AspNetCore.Mvc;
using myApi.Repositories;
namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoRepository videoRepository;
        public VideoController(IVideoRepository videoRepository)
        {
            this.videoRepository = videoRepository;
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetVideoByProductId([FromRoute] Guid id)
        {
            var result = await videoRepository.GetVideoByProductId(id);
            if (result.Count > 0)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}