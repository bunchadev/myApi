
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using myApi.Data;
using myApi.Models.Domain;
using myApi.Models.Dto;

namespace myApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DevDbContext dbContext;
        private readonly IConfiguration configuration;

        public UserRepository(DevDbContext dbContext, IConfiguration configuration)
        {
            this.dbContext = dbContext;
            this.configuration = configuration;
        }

        public async Task<User?> Create(UserRegister userRegister)
        {
            var newUser = new User
            {
                UserName = userRegister.UserName,
                Email = userRegister.Email,
                Password = userRegister.Password,
                Role = "User",
                Money = 10000000,
                PhoneNumber = userRegister.PhoneNumber
            };
            await dbContext.Users.AddAsync(newUser);
            await dbContext.SaveChangesAsync();
            return newUser;
        }
        public async Task<User?> GetByEmail(string email) => await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

        public async Task<User?> GetById(Guid id) => await dbContext.Users.FindAsync(id);

        public async Task<User?> GetByUserName(string username) => await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == username);

        public async Task<JwtUser?> Login(UserLogin userLogin)
        {
            var user = await dbContext.Users.FirstOrDefaultAsync(x => x.UserName == userLogin.UserName);
            if (user != null)
            {
                if (user.Password == userLogin.Password)
                {
                    var claims = new List<Claim>()
                            {
                               new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                               new Claim(ClaimTypes.Role, user.Role),
                            };
                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:Key"] ?? ""));
                    var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var access_token = new JwtSecurityToken( //kiêm tra quyen truy cap của api
                        configuration["Jwt:Issuer"],
                        configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddHours(1),
                        signingCredentials: credentials);
                    var refresh_token = new JwtSecurityToken( //kiêm tra quyen truy cap của api va xac thuc nguoi dung
                        configuration["Jwt:Issuer"],
                        configuration["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddDays(1),
                        signingCredentials: credentials);
                    var jwtAccess_Token = new JwtSecurityTokenHandler().WriteToken(access_token);
                    var jwtRefresh_Token = new JwtSecurityTokenHandler().WriteToken(refresh_token);
                    var result = new JwtUser
                    {
                        access_token = jwtAccess_Token,
                        refresh_token = jwtRefresh_Token,
                        user = user
                    };
                    return result;
                }
                return null;
            }
            return null;
        }
        public async Task<JwtUser?> Refresh_Token(string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var parsedToken = tokenHandler.ReadJwtToken(token);
            var claims1 = parsedToken.Claims;
            var userIdClaim = claims1.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);
            if (userIdClaim != null)
            {
                if (Guid.TryParse(userIdClaim.Value, out Guid userIdGuid))
                {
                    var user = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userIdGuid);
                    if (user != null)
                    {
                        var userT = new UserLogin
                        {
                            UserName = user?.UserName!,
                            Password = user?.Password!
                        };
                        var result = await Login(userT);
                        return result;
                    }
                    return null;
                }
                return null;
            }
            return null;
        }
        public async Task<Message> UpdateMoneyByUser(UpdateUser user)
        {
            if (Guid.TryParse(user.UserId, out Guid res))
            {
                var result = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == res);
                if (result != null && result.Money > user.Money)
                {
                    var num = result.Money - user.Money;
                    result.Money = num;
                    dbContext.Users.Update(result);
                    await dbContext.SaveChangesAsync();
                    return new Message { message = "Cập nhật thành công", statuscode = 200 };
                }
            }
            return null!;
        }
    }
}