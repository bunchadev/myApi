namespace myApi.Models.Domain
{
    public class UserProduct
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public User? User { get; set; }
        public Product? Product { get; set; }
        public string? Type { get; set; } = "KH";
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}