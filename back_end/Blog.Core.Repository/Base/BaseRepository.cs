using Blog.Core.EFCore;
using Blog.Core.IRepository.Base;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Core.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private readonly BlogDbContext BlogContext;
        public DbSet<T> db;
        public int Save;
        public BaseRepository(BlogDbContext blogContext)
        {
            BlogContext = blogContext;
            db = BlogContext.Set<T>();
            Save = BlogContext.SaveChanges();
        }
        #region 查询
        public async Task<T> QueryByID(object objId)
        {
            var entity = db.FindAsync(objId);
            return await entity;
        }
        public async Task<List<T>> Query()
        {
            var entity = db.ToListAsync();
            return await entity;
        }
        public async Task<List<T>> Query(Expression<Func<T, bool>> whereExpression)
        {
            var query = db.AsQueryable();
            if (whereExpression != null)
            {
                query = query.Where(whereExpression);
            }
            return await query.ToListAsync();
        }
        public async Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true) 
        {
            var query = db.AsQueryable();
            if (whereExpression != null)
            {
                query = query.Where(whereExpression);
            }
            if (orderByExpression != null)
            {
                query = isAsc ? query.OrderBy(orderByExpression) : query.OrderByDescending(orderByExpression);
            }
            return await query.ToListAsync();
        }
        #endregion
        #region 添加
        public async Task<int> Add(T model)
        {
            db.Add(model);
            return Save;
        }
        #endregion
        #region 删除
        public async Task<bool> DeleteById(object id)
        {
            var entity = db.Find(id);
            db.Remove(entity);
            return Save > 0;
        }
        public async Task<bool> Delete(T model)
        {
            db.Remove(model);
            return Save > 0;
        }
        public async Task<bool> DeleteByIds(object[] ids)
        {
            foreach (var id in ids)
            {
                var entity = db.Find(id);
                if (entity != null)  
                {
                    db.Remove(entity);
                }
            }
            return Save > 0;
        }
        #endregion
        #region 更新
        public async Task<bool> Update(T model)
        {
            db.Update(model);
            return Save > 0;
        }
        #endregion
        #region 分页
        public async Task<List<T>> GetPageAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> strWhere, bool isAsc, Expression<Func<T, object>> orderByExpression)
        {
            if (pageIndex <= 0)
            {
                pageIndex = 1;
            }
            if (pageSize <= 0)
            {
                pageSize = 10;
            }
            var count = await db.CountAsync(strWhere);  // 获得所有信息的总数
            int skip = (pageIndex - 1) * pageSize; // 计算要跳过的页数
            int take = pageSize; // 获得要选择的一页要多少数量的数据
            var query = db.AsQueryable();
            if (strWhere != null)
            {
                query = query.Where(strWhere);
            }
            if (orderByExpression != null)
            {
                query = isAsc ? query.OrderBy(orderByExpression) : query.OrderByDescending(orderByExpression);
            }
            var result = query.Skip(skip).Take(take).ToList();
            return result;
        }
        #endregion 
    }
}