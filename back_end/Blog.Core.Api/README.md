# Controllers文件夹

表示项目的控制器文件类

# Extension文件夹

表示服务的扩张方法，是将一些服务注册封装在这里

# XML文件夹

存放XML文件，是对Swagger的注释经行存放


# Autofac依赖注入
1. 要引用两个包 : Autofac.Extras.DynamicProxy 、 Autofac.Extensions.DependencyInjection

2. 让Autofac接管ConfigureServices 修改返回类型IServiceProvider 