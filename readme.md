
# Blog.Core.Model : 表示数据层

### Models 存放整个项目的数据库表实体类(自动生成实体类)

### ViewModels 存放Dto实体类,接口一般需要接受数据,返回数据,所以需要Dto实体类当作接受对象(Automaooer实行自动转换)

# Blog.Core.IRepository和 Blog.Core.Repository 仓储层

## Blog.Core.Repository : 管理数据持久层

repository表示仓库管理层,领域层需要什么东西只要向仓储层要,仓储层会提供接口给领域层使用,而仓储层需要的东西则是去数据层拿

## Blog.Core.IRepository : 提供所有仓储层的接口

# Blog.CoreIServices和Blog.CoreServices : 业务逻辑层

领域层是老板但是老板不能直接去仓库找管理员说要什么吧。所以在仓储层之上又有一个业务层对老板服务

Service层只负责将数据层返回的数据进行加工处理，然后给到领域层.它不需要去管仓储层是如何从数据层拿数据的

# 四、采用EFCore的ORM框架去实现对数据库的映射,数据库则是国内最近流行的Postgresql数据库

> dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
> dotnet add package Microsoft.EntityFrameworkCore.Tools
> dotnet add package Microsoft.EntityFrameworkCore
> dotnet add package Microsoft.EntityFrameworkCore.Design
> dotnet ef migrations add one
> dotnet ef database update

**生成迁移文件**
> dotnet ef migrations add one -p .\Blog.Core.FrameWork -s .\Blog.Core\
**更新数据库**
> dotnet ef database update -p .\Blog.Core.FrameWork -s .\Blog.Core

![ 输出 aaa-2021-9-1718:04:33.png](https://gitee.com/lianzengqian/picture/raw/master/%20%E6%A0%BC%E5%BC%8F%201720485491383-2024-7-908:38:12.png%20/%20%E8%BE%93%E5%87%BA%20aaa-2021-9-1718:04:33.png)


### 在linux服务器中如何进入到数据库中

> sudo -u postgres psql
> 使用\du查看所有数据信息
```
CREATE DATABASE psql;
CREATE USER 用户名 WITH PASSWORD '密码';
GRANT ALL PRIVILEGES ON DATABASE psql TO 用户名;
ERROR:  syntax error at or near "/"
```