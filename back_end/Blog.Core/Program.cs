
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore;

namespace Blog.Core;

public class Program
{
    public static void Main(string[] args)
    {
       BuildWebHost(args).Build().Run();
    }
    public static IHostBuilder BuildWebHost(string[] args) 
    {
        return Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())  // ���Autofac��������
            .ConfigureWebHostDefaults(item => 
            {
                item.UseStartup<Startup>();
            });
    }
}
