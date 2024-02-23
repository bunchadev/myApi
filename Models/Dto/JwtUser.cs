using myApi.Models.Domain;

namespace myApi.Models.Dto
{
    public class JwtUser
    {
        public string? access_token { get; set; }
        public string? refresh_token { get; set; }
        public User? user { get; set; }
    }
}