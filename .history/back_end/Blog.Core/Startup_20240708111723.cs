using Microsoft.OpenApi.Models;
using Swashbuckle.Swagger.Model;

namespace Blog.Core
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseEndpoints(item=>item.MapControllers());
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSwaggerGen(item=>{
                item.SwaggerDoc("v1",new OpenApiInfo{
                    Version = "v0.1.0",
                    Title = "Blog.Core API",
                    Description = "框架说明文档",
                    TermsOfService = "None"
                });
            });
        }
    }
}