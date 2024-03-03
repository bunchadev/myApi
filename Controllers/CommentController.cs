using Microsoft.AspNetCore.Mvc;
using myApi.Models.Dto;
using myApi.Repositories;
namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentRepository commentRepository;

        public CommentController(ICommentRepository commentRepository)
        {
            this.commentRepository = commentRepository;
        }
        [HttpGet]
        [Route("{id:guid}")]
        public async Task<IActionResult> getAllComment([FromRoute] Guid id)
        {
            var comment = await commentRepository.getAllComment(id);
            if (comment.Count > 0)
            {
                return Ok(new { statusCode = "200", data = comment });
            }
            return Ok(new { statusCode = "400", data = comment });
        }
        [HttpPost]
        public async Task<IActionResult> createComment([FromBody] CommentDto commentDto)
        {
            var result = await commentRepository.createComment(commentDto);
            return Ok(new { statusCode = result });
        }
    }
}