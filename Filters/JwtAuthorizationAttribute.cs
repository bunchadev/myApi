using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
public class JwtAuthorizationAttribute : ActionFilterAttribute
{
    private readonly string[] requiredRoles;
    public JwtAuthorizationAttribute(params string[] roles)
    {
        this.requiredRoles = roles;
    }
    public override async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
    {
        if (!context.HttpContext.Request.Headers.TryGetValue("Authorization", out var token))
        {
            context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
            return;
        }
        var jwtToken = token.ToString().Split(" ").LastOrDefault();
        if (string.IsNullOrEmpty(jwtToken))
        {
            context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
            return;
        }
        var configuration = context.HttpContext.RequestServices.GetRequiredService<IConfiguration>();
        var key = Encoding.ASCII.GetBytes(configuration["Jwt:Key"] ?? "");
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            tokenHandler.ValidateToken(jwtToken, new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = configuration["Jwt:Issuer"],
                ValidAudience = configuration["Jwt:Audience"],
                IssuerSigningKey = new SymmetricSecurityKey(key),
            }, out var validatedToken);
            var jwtTokenObject = (JwtSecurityToken)validatedToken;
            var userRoles = jwtTokenObject?.Claims.Where(c => c.Type == ClaimTypes.Role).Select(c => c.Value).ToList();
            if (userRoles == null || !userRoles.Any() || !userRoles.Intersect(requiredRoles).Any())
            {
                context.Result = new Microsoft.AspNetCore.Mvc.ForbidResult();
                return;
            }
            context.HttpContext.Items["ValidJwtToken"] = true;
            await next();
        }
        catch (Exception)
        {
            context.Result = new Microsoft.AspNetCore.Mvc.UnauthorizedResult();
        }
    }
}
