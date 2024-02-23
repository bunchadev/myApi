namespace myApi.Models.Domain
{
    public class Image
    {
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public byte[] File { get; set; } = null!;
        public string ImageName { get; set; } = null!;
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}