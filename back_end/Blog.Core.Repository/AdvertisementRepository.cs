using Blog.Core.IRepository;
using Blog.Core.Model;
using Blog.Core.Model.Models;
using Blog.Core.Repository.sugar;
using SqlSugar;
using System.Linq.Expressions;


namespace Blog.Core.Repository
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private DbContext context;
        private SqlSugarClient db;
        private SimpleClient<Advertisement> entityDb;
        internal SqlSugarClient Db
        {
            get { return db; }
            private set { db = value; }
        }
        public DbContext Context
        {
            get { return context; }
            set { context = value; }
        }
        public AdvertisementRepository() 
        {
            DbContext.Init(BaseDBConfig.ConnectionString); // 用来初始化数据库上下文
            context = DbContext.GetDbContext(); // 获取数据库上下文的实例
            db = context.Db; // 将实例的属性赋值给db
            entityDb = context.GetEntityDB<Advertisement>(db); // 获取实体集合
        }
        public int Add(Advertisement model)
        {
            var i = db.Insertable(model).ExecuteReturnBigIdentity(); //将实体模型插入至数据库中,并设置自增并返回主键值
            return i.ObjToInt(); // 返回i对象的整数
        }

        public bool Delete(Advertisement model)
        {
            var i = db.Deleteable(model).ExecuteCommand(); //ExecuteCommand返回被影响的行数
            return i > 0;
        }
        //whereexpression 表示一个表达式 ad => ad.Category == "Technology" && ad.IsActive == true
        public List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression)
        {
            return entityDb.GetList(whereExpression);
        }

        public int Sum(int i, int j)
        {
            return i + j;
        }

        public bool Update(Advertisement model)
        {
            var i = db.Updateable(model).ExecuteCommand(); // 返回被影响的行数
            return i > 0;
        }
    }
}
