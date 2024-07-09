
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

