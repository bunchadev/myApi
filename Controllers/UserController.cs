using Microsoft.AspNetCore.Mvc;
using myApi.Models.Dto;
using myApi.Services;
namespace myApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] UserRegister UserRegister)
        {
            try
            {
                var result = await userService.Register(UserRegister);
                return Ok(new { statusCode = "200", user = result });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLogin userLogin)
        {
            try
            {
                var result = await userService.Login(userLogin);
                if (result == null)
                {
                    return Ok(new { message = "Username không tồn tại hoặc mật khẩu của bạn đã sai!!!", statusCode = "400" });
                }
                return Ok(new { statusCode = "200", data = result });
            }
            catch (System.Exception)
            {
                throw;
            }
        }
        [HttpPost]
        [Route("refresh_token")]
        public async Task<IActionResult> Refresh_token([FromBody] string token)
        {
            var result = await userService.Refresh_Token(token);
            if (result == null)
            {
                return Ok(new { StatusCode = "400" });
            }
            else
            {
                return Ok(new { StatusCode = "202", data = result });
            }
        }
        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateMoneyByUser([FromBody] UpdateUser user)
        {
            var result = await userService.UpdateMoneyByUser(user);
            if (result != null)
            {
                return Ok(result);
            }
            return Ok(new Message { message = "Không thể update!!", statuscode = 400 });
        }
    }
}