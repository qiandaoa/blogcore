using Blog.Core.Extension;
using Blog.Core.Extension.JWT;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Blog.Core
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // 用于注册服务
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddAuthentication();
            //services.AddAuthorization();
            services.AddCORS(); // 注册cors到容器中
            services.AddMvc(); // 注册MVC到Container "Container"通常指的是依赖注入容器，也称为 IoC 容器    
            services.AddSwagger();// 注册swagger服务到容器
            services.AddJwt(Configuration);
        }

        // 用于启动注册的服务
        public void Configure(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseCors("CorsTest"); // 启动跨域配置文件
            app.UseAuthentication(); // 开启认证
            app.UseSwagger(); // 启用Swagger
            app.UseSwaggerUI(c => // 启动swaggerui的描述
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiHelp V1");
            });
            app.UseRouting(); // 使用路由
            
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
