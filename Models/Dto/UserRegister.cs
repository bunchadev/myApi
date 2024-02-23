namespace myApi.Models.Dto
{
    public class UserRegister
    {
        public string UserName { get; set; } = null!;
        public string Password { get; set; } = null!;
        public string? PhoneNumber { get; set; }
        public string? Email { get; set; }
    }
}