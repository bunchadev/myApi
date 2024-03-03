using myApi.Models.Domain;
using myApi.Models.Dto;
namespace myApi.Repositories
{
    public interface ICommentRepository
    {
        Task<List<Comment>> getAllComment(Guid id);
        Task<string> createComment(CommentDto commentDto);
    }
}