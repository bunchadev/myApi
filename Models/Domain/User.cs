namespace myApi.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }
        public string? UserName { get; set; }
        public string Password { get; set; } = null!;
        public string Role { get; set; } = null!;
        public int Money { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}