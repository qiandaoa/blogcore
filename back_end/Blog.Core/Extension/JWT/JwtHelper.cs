using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Core.Extension.JWT
{
    public class JwtHelper
    {
        
        public class TokenModelJwt
        {
            /// <summary>
            /// Id
            /// </summary>
            public long Uid { get; set; }
            /// <summary>
            /// 角色
            /// </summary>
            public string Role { get; set; }
            /// <summary>
            /// 职业
            /// </summary>
            public string Work { get; set; }
        }
        /// <summary>
        /// 颁发token
        /// </summary>
        /// <returns></returns>
        public static string IssueJwt(TokenModelJwt tokenModelJwt, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("Audience");
            var secret = jwtSettings["Secret"];
            var issuer = jwtSettings["Issuer"];
            var audience = jwtSettings["Audience"];
            // 创建一个简单的token
            // 创建一个声明数组(也就是身份证)
            var Claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name,"blog_name"),
                new Claim(JwtRegisteredClaimNames.Jti,tokenModelJwt.Uid.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub,"1")
            };
            // 因为一个身份证可能存在多个角色,所以向其添加
            Claims.AddRange(tokenModelJwt.Role.Split(',').Select(s => new Claim(ClaimTypes.Role, s)));
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secret)); // 密钥,至少16位
            // 实例化 token对象 claims表示身份证的主人
            var token = new JwtSecurityToken
            (
                issuer: issuer, // 发行人,代表项目
                audience: audience, // 订阅人,代表谁使用这个项目
                claims: Claims,
                expires: DateTime.Now.AddHours(1), //过期时间,1个小时后过期
                signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256) // 设置加密算法
            );
            // 生成Token
            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return jwtToken;
        }
        // 获取前端发送过来的token(有三种方式)
        // 但是前端发送的数据只有token没有身份证的主人所以这是要在服务中添加主人
        public static string SeralizeJwt(string jwtStr)
        {
            var jwtHandler = new JwtSecurityTokenHandler();
            JwtSecurityToken jwtToken = jwtHandler.ReadJwtToken(jwtStr);
            return JsonConvert.SerializeObject(jwtToken);
        }
    }
}
