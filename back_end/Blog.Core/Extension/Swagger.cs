using Microsoft.Extensions.Caching.Memory;
using Microsoft.OpenApi.Models;

namespace Blog.Core.Extension
{
    public static class Swagger
    {
        // 封装Swagger
        public static void AddSwagger(this IServiceCollection services) 
        {
            services.AddSwaggerGen(item =>
            {
                // 用于指定API文档的版本和相关信息
                item.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "0.0.1",
                    Title = "Blog.Core API",
                    Description = "框架说明文档",
                    TermsOfService = null,
                    Contact = new OpenApiContact { Name = "Simple", Email = string.Empty, Url = null }
                });
                #region 读取xml信息
                var basePath = AppContext.BaseDirectory ; // 获取应用程序的基本目录路径
                var xmlPath = Path.Combine(basePath, "Blog.Core.xml") ;  //将基本路径组成一个完成的路径
                item.IncludeXmlComments(xmlPath, true); // 表示将xml注释文件添加到swagger生成器中,xmlpath表示xml的位置，true表示启动xml的详细注释信息
                var xmlModelPath = Path.Combine(basePath, "Blog.Core.Model.xml");
                item.IncludeXmlComments(xmlModelPath);
                #endregion
                #region 将Token绑定到ConfigureServices
                // 开启JWT服务,添加安全定义
                item.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
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
                        Array.Empty<string>()
                    }
                });
                #endregion
            });
           
        }
    }
}
