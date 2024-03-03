using myApi.Data;
using myApi.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace myApi.Repositories
{
    public class LessonContentRepository : ILessonContentRepository
    {
        private readonly DevDbContext dbContext;

        public LessonContentRepository(DevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<LessonContentDto> GetLessonContentByProductId(Guid id)
        {
            var lessonContents = await dbContext.LessonContents.Where(x => x.ProductId == id).ToListAsync();
            if (lessonContents.Count > 0)
            {
                var data = new LessonContentDto();
                List<string?> result = lessonContents.Select(x => x.Title).ToList() ?? new List<string?>();
                if (result.Count > 0)
                {
                    data.Title = result;
                    return data;
                }
            }
            return new LessonContentDto { Title = [] };
        }
    }
}