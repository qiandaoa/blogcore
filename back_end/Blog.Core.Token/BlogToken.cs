using Blog.Core.Token.Model;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Blog.Core.Token
{
    public class BlogToken
    {
        public BlogToken() { }
        /// <summary>
        /// 获取jwt字符串并存入缓存中,用来颁发JWT
        /// </summary>
        /// <param name="tokenModel">这个是自定义的类,有一些用户信息</param>
        /// <param name="expiresSliding">用来设置JWT的过期时间(滑动时间)</param>
        /// <param name="expiresAbsoulte">绝对过期时间(就是Jwt的最长有效时间)</param>
        /// <returns></returns>
        public static string IssueJWT(TokenModel tokenModel,TimeSpan expiresSliding,TimeSpan expiresAbsoulte)
        {
            DateTime UTC = DateTime.UtcNow; // 表示获取当前时间
            Claim[] claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Sub,tokenModel.Sub), // 表示jwt的身份
                new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()), // 表示jwt的唯一表示
                new Claim(JwtRegisteredClaimNames.Iat,ClaimValueTypes.Integer64), // jwt颁发的时间,采用unix时间,用于验证过期
            };
            JwtSecurityToken jwt = new JwtSecurityToken
            (
                issuer:"Blog",//JWT签收方
                audience:tokenModel.Uname, // JWT接受方
                claims:claims, //在jwt被验证时使用
                expires:UTC.AddHours(12), // 过期于12个小时之后
                // 表示jwt签名凭据,使用一个密钥和一个签名算法创建的
                signingCredentials:new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes("BLOG key")),SecurityAlgorithms.HmacSha256)
             );
            // 将上面的jwt序列化转成jwt字符串
            var encodeJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            // 向缓存中添加一个键值对和滑动时间和绝对过期时间
            BlogMemoryCache.AddMemoryCache(encodeJwt,tokenModel,expiresSliding,expiresAbsoulte);
            return encodeJwt;
        }
    }
}
