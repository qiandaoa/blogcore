using Blog.Core.Token;
using Blog.Core.Token.Model;
using System.Security.Claims;

namespace Blog.Core.AuthHelper
{
    /// <summary>
    /// Token验证授权中间件
    /// </summary>
    public class TokenAuth
    {
        /// <summary>
        /// http委托
        /// </summary>
        private readonly RequestDelegate _next;
        public TokenAuth(RequestDelegate next) // RequestDeletegate是一个用于处理http
        {
            _next = next;
        }
        public Task Invoke(HttpContext httpContext)
        {
            var headers = httpContext.Request.Headers; // 获取请求头
            if (!headers.ContainsKey("Authorization")) // 判断是否这个Authorization
            {
                return _next(httpContext); //不存在,放回请求体
            }
            var tokenStr = headers["Authorization"];//赋值给tokenstr
            try
            {
                // 例子: Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxMjM0NTY3ODkwIiwibmFtZSI6IkpvaG4gRG9lIiwiaWF0IjoxNTE2MjM5MDIyfQ.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5
                string jwtStr = tokenStr.ToString().Substring("Bearer".Length).Trim(); //用于获取Boeare之后的字符(jwt)
                // 检查缓存中是否有jwt这个字符 如果没有返回给客服端一个"非法请求"
                if (!BlogMemoryCache.Exists(jwtStr))
                {
                    return httpContext.Response.WriteAsync("非法请求");
                }
                // 调用这个方法,得到jwt对应的值
                TokenModel tm = ((TokenModel)BlogMemoryCache.Get(jwtStr));
                List<Claim> lc = new List<Claim>();
                // 创建一个Claim对象(表示每个声明都是由一个类型和值组成的)
                Claim c = new Claim(tm.Sub + "Type", tm.Sub);
                lc.Add(c); // 转化成一个表示用户信息的对象
                ClaimsIdentity identity = new ClaimsIdentity(lc);// 将用户信息转成成一个身份对象
                ClaimsPrincipal principal = new ClaimsPrincipal(identity); // 将其转换成为一个具有身份的用户
                httpContext.User = principal; 
                return _next(httpContext);
            }
            catch (Exception) // 检测到报错
            {
                return httpContext.Response.WriteAsync("token验证异常");
            }
        }
    }
}
