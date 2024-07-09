using Blog.Core.FrameWork;
using Blog.Core.IRepository;
using Blog.Core.IServices;
using Blog.Core.Repository;
using Blog.Core.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace Blog.Core
{
    public class Startup
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        private readonly IConfiguration Configuration;
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(item=>item.MapControllers());
            app.UseSwagger(options =>
            {
                options.RouteTemplate = "swagger/{documentName}/swagger.json";
            });
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<BlogDbContext>(optinos=>{
                optinos.UseNpgsql(Configuration.GetConnectionString("psql"));
            });
        }
    }
}