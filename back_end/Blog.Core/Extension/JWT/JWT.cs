using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Blog.Core.Extension.JWT
{
    public static class JWT
    {
        public static void AddJwt(this IServiceCollection services,IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Audience");
            var secret = jwtSettings["Secret"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            // 认证对发送来的token经行解密
            var TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secret)),
                ValidateIssuer = true,
                ValidIssuer = issuer, // 可以将共有的参数写到配置文件中防止两套参数不一样
                ValidateAudience = true,
                ValidAudience = audience,
                ClockSkew = TimeSpan.FromSeconds(30),
                RequireExpirationTime = true
            };
            services.AddAuthentication("Bearer").AddJwtBearer(item =>
            {
                item.TokenValidationParameters = TokenValidationParameters;
            });
        }
    }
}
