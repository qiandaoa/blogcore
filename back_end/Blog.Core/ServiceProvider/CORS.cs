namespace Blog.Core.ServiceProvider
{
    public static class CORS
    {
        public static void AddCORS(this IServiceCollection services)
        {
            services.AddCors(item => item.AddPolicy
            (
                "CorsTest",
                policy=>policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()
            ));
        }
    }
}
