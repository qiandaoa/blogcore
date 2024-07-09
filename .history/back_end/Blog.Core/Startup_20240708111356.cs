using System;
using System.Collections.Generic;
using Swashbuckle.AspNetCore.Swagger;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.OpenApi.Models; // 添加这行引用

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
                item.SwaggerDoc("v1",new Info{
                    Version = "v0.1.0",
                    Title = "Blog.Core API",
                    Description = "框架说明文档",
                    TermsOfService = "None"
                });
            });
        }
    }
}