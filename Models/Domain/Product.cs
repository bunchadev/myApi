namespace myApi.Models.Domain
{
    public class Product
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string? NameTitle { get; set; }
        public string Author { get; set; } = null!;
        public int? NumberStudents { get; set; }
        public double? Evaluate { get; set; }
        public int? Price { get; set; }
        public string? Type { get; set; } = null!;
        public string? FileName { get; set; }
        public ICollection<LessonContent>? LessonContents { get; set; }
        public ICollection<Video>? Videos { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}