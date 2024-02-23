namespace myApi.Models.Domain
{
    public class UserCart
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public Guid ProductId { get; set; }
        public Product? product { get; set; }
    }
}