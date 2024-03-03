using myApi.Models.Dto;


namespace myApi.Repositories
{
    public interface IVideoRepository
    {
        Task<List<VideoDto>> GetVideoByProductId(Guid id);
    }
}