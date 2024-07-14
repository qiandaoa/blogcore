using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Blog.Core.ServiceProvider
{
    public static class JWT
    {
        public static bool AudienceValidator(IEnumerable<string> audiences,SecurityToken securityToken,TokenValidationParameters tokenValidationParameters)
        {
            return Audiences.IsNewestAudience(audiences.FirstOrDefault());
        }
     
        public static void AddJWT(this IServiceCollection services)
        {
            //它在处理请求时检查请求头部中是否包含身份验证信息，如果包含则进行身份验证并将用户标识存储在 HttpContext.User 属性中。
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme) // 配置默认验证方案
                .AddJwtBearer(o => 
                {
                    o.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateLifetime = true, //是否JWT验证失效时间
                        ClockSkew = TimeSpan.FromSeconds(30), // 设置JWT的有效时长
                        ValidateAudience = true, //是否核实身份
                        AudienceValidator = AudienceValidator, // 动态刷新验证方式,在重新登录时,旧的token就强制失效
                        ValidateIssuer = false, // 是否验证签发人
                        ValidateIssuerSigningKey = true, // 是否验证签发人的签名key
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Const.SecurityKey)) // 设置密钥
                    };
                });   
        }
    }
}
