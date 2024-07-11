using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Repository.sugar
{
    public class BaseDBConfig
    {
        /// <summary>
        /// 采用配置文件的形式，因为项目需要提交至gitee上。所以要对连接数据的操作采取本地文件配置
        /// </summary>
        public static string ConnectionString = File.ReadAllText(@"E:\GitU盘\连接数据库\BlogCount.txt");
    }
}
