namespace myApi.Dto.Domain
{
    public class createProduct
    {
        public string? UserId { get; set; }
        public string ProductName { get; set; } = null!;
        public string Description { get; set; } = null!;
        public string Author { get; set; } = null!;
        public int? Price { get; set; }
        public string? Type { get; set; } = null!;
        public string? FileName { get; set; }
    }
}