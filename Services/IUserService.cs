using myApi.Models.Domain;
using myApi.Models.Dto;

namespace myApi.Services
{
    public interface IUserService
    {
        Task<User?> Register(UserRegister userRegister);
        Task<JwtUser?> Login(UserLogin userLogin);
        Task<JwtUser?> Refresh_Token(string token);
        Task<Message> UpdateMoneyByUser(UpdateUser user);
    }
}