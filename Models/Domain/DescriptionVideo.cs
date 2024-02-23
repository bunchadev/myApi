namespace myApi.Models.Domain
{
    public class DescriptionVideo
    {
        public int Id { get; set; }
        public int VideoId { get; set; }
        public string? TitleVideo { get; set; }
        public string? TimeVideo { get; set; }
    }
}