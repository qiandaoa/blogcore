using Autofac;
using Blog.Core.EFCore;
using Blog.Core.Extension;
using Blog.Core.Extension.JWT;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Blog.Core.Api
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            // 注册要通过的反射创建的组件
            // builder.RegisterType<实现类>().As<接口>();
            // 将整个服务程序集经行注入(未解耦)
            var assemblysServices = Assembly.Load("Blog.Core.Services"); // 这里注入的必须要是实现类 Load解决方案名称
            builder.RegisterAssemblyTypes(assemblysServices).AsImplementedInterfaces(); // 扫描整个程序集为提供所有其实现的接口
            var assemblysRepository = Assembly.Load("Blog.Core.Repository");
            builder.RegisterAssemblyTypes(assemblysRepository).AsImplementedInterfaces();
        }
        // 用于注册服务
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BlogDbContext>(item => 
            {
                //item.UseNpgsql("host=101.133.150.189;port=5432;database=blog;uid=blog;pwd=2071260354");
                item.UseNpgsql(File.ReadAllText(@"E:\GitU盘\连接数据库\BlogConnect.txt"));//采用读取本地文件的形式,因为源码开源(所以不能让访客看到服务器密码) 
            });
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
            app.UseAuthorization(); // 开启token认证
            app.UseEndpoints(endpoints => 
            {
                endpoints.MapControllers();
            });
        }
    }
}
