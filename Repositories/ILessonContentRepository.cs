using myApi.Models.Dto;

namespace myApi.Repositories
{
    public interface ILessonContentRepository
    {
        Task<LessonContentDto> GetLessonContentByProductId(Guid id);
    }
}