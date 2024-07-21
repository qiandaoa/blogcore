using Autofac.Extensions.DependencyInjection;

namespace Blog.Core.Api;

public class Program
{
    public static void Main(string[] args)
    {
       BuildWebHost(args).Build().Run();
    }
    public static IHostBuilder BuildWebHost(string[] args) 
    {
        return Host.CreateDefaultBuilder(args)
            .UseServiceProviderFactory(new AutofacServiceProviderFactory())  // 添加Autofac工厂服务
            .ConfigureWebHostDefaults(item => 
            {
                item.UseStartup<Startup>();
            });
    }
}
