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
            app.UseSwaggerUI(item=>
            {
                item.SwaggerEndpoint("/swagger/v1/swagger.json","Blog.Core API");
            });
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            /// swagger
            services.AddSwaggerGen(item=>{
                item.SwaggerDoc("v1",new OpenApiInfo{
                    Version = "v0.1.0",
                    Title = "Blog.Core API",
                    Description = "框架说明文档",
                    TermsOfService = new Uri("https://example.com/terms"),
                });
            });
            services.AddDbContext<BlogDbContext>(optinos=>{
                optinos.UseNpgsql(Configuration.GetConnectionString("psql"));
            });
            services.AddScoped<AdvertisementRepository>();
            services.AddScoped(typeof(IAdvertisementServices), typeof(AdvertisementServices));
            services.AddScoped(typeof(IAdvertisementRepository), typeof(AdvertisementRepository));
        }
    }
}