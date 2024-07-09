using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Components.Web;

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
        );
        }
    }
}