namespace myApi.Models.Dto
{
    public class UserPDto
    {
        public string UserId { get; set; } = null!;
        public List<Guid> ProductId { get; set; } = null!;
    }
}