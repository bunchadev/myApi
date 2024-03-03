using myApi.Models.Domain;
using myApi.Models.Dto;
using myApi.Repositories;

namespace myApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository userRepository;
        public UserService(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public async Task<JwtUser?> Login(UserLogin userLogin) => await userRepository.Login(userLogin);
        public async Task<JwtUser?> Refresh_Token(string token) => await userRepository.Refresh_Token(token);
        public async Task<User?> Register(UserRegister userRegister)
        {
            var userName = await userRepository.GetByUserName(userRegister.UserName);
            if (userName != null)
            {
                throw new ArgumentException("UserName already exists!!!");
            }
            var email = await userRepository.GetByEmail(userRegister.Email ?? "");
            if (email != null)
            {
                throw new ArgumentException("Email already exits!!!");
            }
            return await userRepository.Create(userRegister);
        }
        public async Task<Message> UpdateMoneyByUser(UpdateUser user) => await userRepository.UpdateMoneyByUser(user);
    }
}