# 框架

## 一.使用Swagger框架

Swagger是一个书写API文档的框架

## 二.对项目框架的搭建

> Blog.Core: 表示对外暴露的API层

- ServiceProvider: 用于封装Swagger和Cors

- Data:用来封装数据库上下文,使用efcore作为orm框架

  连接数据库,采用的是代码先行

  > dotnet ef migrations add one --project .\Blog.Core\ 生成迁移文件

  > dotnet ef update database --project .\Blog.Core\ 生成数据表

> Blog.Core.Model:表示对核心实体层

- Models文件夹中，存放的是整个项目的数据库表实体类
- VeiwModels文件夹，是存放的DTO实体类，在开发中，一般接口需要接收数据，返回数据

> Blog.Core.Repository和Blog.Core.IRepository:仓储层

**Repository 是仓库管理员，领域层需要什么东西只需告诉仓库管理员，由仓库管理员把东西拿给它，并不需要知道东西实际放在哪。**

> Blog.Core.Service和Blog.Core.IService:业务层



