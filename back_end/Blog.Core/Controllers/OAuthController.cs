using Blog.Core.Dto;
using Blog.Core.ServiceProvider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace Blog.Core.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Authenticate(string name, string password)
        {
            var user = new UserProviderDto(name, password);
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Const.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = Audiences.UpdateAudience(user.Name),
                Subject = user.GetClaimsIdentity()
                Expires  = DateTime.UtcNow.AddDays(0.5)
            };
        }
    }
}
