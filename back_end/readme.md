# 框架

## 一.使用Swagger框架

Swagger是一个书写API文档的框架

## JWT的权限验证

TokenModel.cs:用于存放用户信息

BlogMemoryCache.cs：用于表示对系统缓存的操作

BlogToken.cs：用于生成jwt

TokenAuth.cs: 表示中间件,用于验证

![](https://images2018.cnblogs.com/blog/1468246/201809/1468246-20180904113555931-616143177.png)

## 二.对项目框架的搭建

> Blog.Core: 表示对外暴露的API层
>
> Blog.Core.Model:表示对核心实体层

- Models文件夹中，存放的是整个项目的数据库表实体类
- VeiwModels文件夹，是存放的DTO实体类，在开发中，一般接口需要接收数据，返回数据

> Blog.Core.Token：对jwt的颁发,属于一个独立项目
>
> Blog.Core.Repository和Blog.Core.IRepository:仓储层

**Repository 是仓库管理员，领域层需要什么东西只需告诉仓库管理员，由仓库管理员把东西拿给它，并不需要知道东西实际放在哪。**

> Blog.Core.Service和Blog.Core.IService:业务层

