using Microsoft.AspNetCore.Mvc;
using myApi.Repositories;
namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LessonContentController : ControllerBase
    {
        private readonly ILessonContentRepository lessonContentRepository;
        public LessonContentController(ILessonContentRepository lessonContentRepository)
        {
            this.lessonContentRepository = lessonContentRepository;
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> GetLessonContentByProductId([FromRoute] Guid id)
        {
            var result = await lessonContentRepository.GetLessonContentByProductId(id);
            if (result != null)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}