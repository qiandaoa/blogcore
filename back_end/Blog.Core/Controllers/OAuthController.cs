using Blog.Core.Extension.JWT;
using Blog.Core.IRepository.Base;
using Blog.Core.Model.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using static Blog.Core.Extension.JWT.JwtHelper;

namespace Blog.Core.Controllers
{
    //[Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OAuthController : ControllerBase
    {
        public IConfiguration Configuration { get; set; }
        public OAuthController(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        [HttpGet]
        public async Task<object> GetJwtStr()
        {
            TokenModelJwt tokenModel = new TokenModelJwt { Uid=1,Role="Admin"};
            var jwt = IssueJwt(tokenModel, Configuration); // 调用生成token令牌
            return Ok(jwt);
        }
        [HttpGet("/one")]
        public async Task<object> GetJwtStr(string name, string pass)
        {
            // 将用户id和角色名，作为单独的自定义变量封装进 token 字符串中。
            TokenModelJwt tokenModel = new TokenModelJwt { Uid = 1, Role = "Admin" };
            var jwtStr = IssueJwt(tokenModel, Configuration);//登录，获取到一定规则的 Token 令牌
            var suc = true;
            return Ok(new
            {
                success = suc,
                token = jwtStr
            });
        }

    }
}
