using myApi.Data;
using myApi.Models.Domain;
using myApi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace myApi.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly DevDbContext dbContext;

        public CommentRepository(DevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<string> createComment(CommentDto commentDto)
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
                return "200";
            }
            return "400";
        }

        public async Task<List<Comment>> getAllComment(Guid id)
        {
            var comment = await dbContext.Comments.Where(x => x.ProductId == id).ToListAsync();
            if (comment.Count > 0)
            {
                return comment;
            }
            return [];
        }
    }
}