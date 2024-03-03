using Microsoft.EntityFrameworkCore;
using myApi.Data;
using myApi.Models.Dto;

namespace myApi.Repositories
{
    public class VideoRepository : IVideoRepository
    {
        private readonly DevDbContext dbContext;
        public VideoRepository(DevDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<List<VideoDto>> GetVideoByProductId(Guid id)
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
                return result;
            }
            return [];
        }
    }
}