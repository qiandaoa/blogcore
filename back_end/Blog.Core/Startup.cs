using Blog.Core.Data;
using Blog.Core.ServiceProvider;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Blog.Core
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddJWT(); // 将扩展的JWT注册至容器当中
            services.AddDbContext<BlogContext>(item => item.UseNpgsql(File.ReadAllText(@"E:\GitU盘\连接数据库\BlogConnect.txt"))); //数据库连接配置.采用配置文件的形式
            services.AddCORS(); // 注册cors到容器中
            services.AddMvc(); // 注册MVC到Container "Container"通常指的是依赖注入容器，也称为 IoC 容器    
            services.AddSwagger();// 注册swagger服务到容器
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication(); // 用于配置身份验证，它在处理请求时检查请求头部中是否包含身份验证信息，如果包含则进行身份验证并将用户标识存储在 HttpContext.User 属性中。
            app.UseCors("CorsTest"); // 启动跨域配置文件
            app.UseSwagger(); // 启用Swagger
            app.UseSwaggerUI(c => // 启动swaggerui的描述
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });
            app.UseRouting(); // 使用路由
            app.UseAuthorization(); //用于配置授权，它在处理请求时检查 HttpContext.User 属性中包含的用户标识，并根据配置的策略来确定用户是否有权访问请求的资源。
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
