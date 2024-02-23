namespace myApi.Models.Dto
{
    public class ProductDto
    {
        public Guid Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int? NumberStudents { get; set; }
        public double? Evaluate { get; set; }
        public int? Price { get; set; }
        public string? Type { get; set; } = null!;
        public string? FileName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}