using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.Swagger;

namespace Blog.Core
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app,ISwaggerProvider)
        {
            app.UseRouting();
            app.UseEndpoints(item=>item.MapControllers());
            app.UseSwagger();
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
        }
    }
}