namespace myApi.Models.Domain
{
    public class Comment
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public string? UserName { get; set; }
        public string? Title { get; set; }
        public double? evaluate { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}