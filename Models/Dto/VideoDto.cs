namespace myApi.Models.Dto
{
    public class VideoDto
    {
        public string? Title { get; set; }
        public ICollection<DescriptionVideoDto>? DescriptionVideoDtos { get; set; }
    }
}