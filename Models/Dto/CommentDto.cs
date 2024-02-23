namespace myApi.Models.Dto
{
    public class CommentDto
    {
        public Guid ProductId { get; set; }
        public string? UserName { get; set; }
        public string? Title { get; set; }
        public double? evaluate { get; set; }
    }
}