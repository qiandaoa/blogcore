using Blog.Core.IRepository.Base;
using System.Linq.Expressions;

namespace Blog.Core.Services.Base
{
    public class BaseServices<T> : IBaseRepository<T> where T : class, new()
    {
        public Task<int> Add(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(T model)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteById(object id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> DeleteByIds(object[] ids)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query()
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> Query(string strWhere)
        {
            throw new NotImplementedException();
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

        public Task<T> QueryByID(object objId)
        {
            throw new NotImplementedException();
        }

        public Task<T> QueryByID(object objId, bool blnUseCache = false)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> QueryByIDs(object[] lstIds)
        {
            throw new NotImplementedException();
        }

        public Task<List<T>> QueryPage(Expression<Func<T, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(T model)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(Expression<Func<T, bool>> strWhere, Expression<Func<T, T>> entity)
        {
            throw new NotImplementedException();
        }
    }
}
