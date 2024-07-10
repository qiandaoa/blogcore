
using Blog.Core.AuthHelper;
using Blog.Core.Token;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace Blog.Core
{
    public class Startup
    {
        private readonly IConfiguration Configuration;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="configuration"></param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(); // 注册MVC到Container "Container"通常指的是依赖注入容器，也称为 IoC 容器
            #region Swagger
            services.AddSwaggerGen(item => 
            {
                // 用于指定API文档的版本和相关信息
                item.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Blog.Core API",
                    Description = "框架说明文档"
                });
                #region 读取xml信息
                var basePath = AppContext.BaseDirectory; // 获取应用程序的基本目录路径
                var xmlPath = Path.Combine(basePath, "Blog.Core.xml");  //将基本路径组成一个完成的路径
                item.IncludeXmlComments(xmlPath,true); // 表示将xml注释文件添加到swagger生成器中,xmlpath表示xml的位置，true表示启动xml的详细注释信息
                var xmlModelPath = Path.Combine(basePath, "Blog.Core.Model.xml");
                item.IncludeXmlComments(xmlModelPath);
                #endregion
                #region 将Token绑定到ConfigureServices
                // 开启JWT服务,添加安全定义
                item.AddSecurityDefinition("Blog.Core", new OpenApiSecurityScheme
                {
                    Description = "JWT授权(数据将在请求头中进行传输) 参数结构: \"Authorization: Bearer {token}\"",
                    Name = "Authorization",//jwt默认的参数名称
                    In = ParameterLocation.Header,//jwt默认存放Authorization信息的位置(请求头中)
                    Type = SecuritySchemeType.ApiKey
                });
                // 添加安全要求
                item.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
                #endregion
            });
            #endregion
            // 注册缓存服务项
            services.AddSingleton<IMemoryCache>(factory =>
            {
                var cache = new MemoryCache(new MemoryCacheOptions());
                return cache;
            });
            // 认证 认证了三个身份 system client admin
            services.AddAuthorization(options =>
            {
                options.AddPolicy("System", policy => policy.RequireClaim("SystemType").Build());
                options.AddPolicy("Client", policy => policy.RequireClaim("ClientType").Build());
                options.AddPolicy("Admin", policy => policy.RequireClaim("AdminType").Build());
            });
            


        }
        public void Configure(IApplicationBuilder app)
        {
            #region Swagger
            app.UseSwagger();
            app.UseSwaggerUI();
            #endregion
            app.UseMiddleware<TokenAuth>(); // 表示在http请求中处理http请求的一个中间件
            app.UseRouting();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            
        }
    }
}
