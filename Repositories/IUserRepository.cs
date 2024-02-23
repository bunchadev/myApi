using myApi.Models.Domain;
using myApi.Models.Dto;

namespace myApi.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(Guid id);
        Task<User?> GetByUserName(string username);
        Task<User?> GetByEmail(string email);
        Task<User?> Create(UserRegister userRegister);
        Task<JwtUser?> Login(UserLogin userLogin);
        Task<JwtUser?> Refresh_Token(string token);
        Task<Message> UpdateMoneyByUser(UpdateUser user);
    }
}