# 在sln同级目录下:

1. 生成迁移文件：
   
   >   dotnet ef migrations add Init_Rbac -p .\Blog.Core.Repository -s .\Blog.Core
2. 同步迁移文件
   
   >  dotnet ef database update -p .\Blog.Repository -s .\Blog.Core

