using Blog.Core.IRepository.Base;
using Blog.Core.Repository.EFCore;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Blog.Core.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
        private readonly BlogContext BlogContext;
        public DbSet<T> db;
        public int Save;
        public BaseRepository(BlogContext blogContext)
        {
            BlogContext = blogContext;
            db = BlogContext.Set<T>();
            Save = BlogContext.SaveChanges();
        }
        #region 查询
        public async Task<T> QueryByID(object objId)
        {
            return await db.FindAsync(objId);
        }

        public async Task<T> QueryByID(object objId, bool blnUseCache = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> QueryByIDs(object[] lstIds)
        {
            throw new Exception();
        }
        public Task<List<T>> Query()
        {
            return db.ToListAsync();
        }

        public Task<List<T>> Query(string strWhere)
        {
            if (string.IsNullOrEmpty(strWhere))
            {
                throw new Exception();
            }
            throw new Exception();
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(string strWhere, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intTop, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(string strWhere, int intTop, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> QueryPage(Expression<Func<T, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region 添加
        public async Task<int> Add(T model)
        {
            await db.AddAsync(model);
            return await BlogContext.SaveChangesAsync();
        }
        #endregion
        #region 删除
        public async Task<bool> Delete(T model)
        {
            db.Remove(model);
            return Save > 0;
        }

        public async Task<bool> DeleteById(object id)
        {
            var entity = await db.FindAsync(id);
            if (entity == null)
            {
                return false;
            }
            db.Remove(entity);
            return Save > 0;
        }

        public async Task<bool> DeleteByIds(object[] ids)
        {
            var entites = await db.FindAsync(ids);
            if (entites == null)
            {
                return false;
            }
            db.RemoveRange(entites);
            return Save > 0;
        }
        #endregion
        #region 更新
        public async Task<bool> Update(T model)
        {
            db.Update(model);
            return Save > 0;

        }
         // 暂时写不出来
        public Task<int> Update(Expression<Func<T, bool>> strWhere, Expression<Func<T, T>> entity)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}