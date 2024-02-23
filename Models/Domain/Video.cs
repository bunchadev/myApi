namespace myApi.Models.Domain
{
    public class Video
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public string? Title { get; set; }
        public ICollection<DescriptionVideo>? DescriptionVideos { get; set; }
    }
}