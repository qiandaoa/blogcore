using Blog.Core.IRepository.Base;
using System.Linq.Expressions;

namespace Blog.Core.Services.Base
{
    public class BaseServices<T> : IBaseServices<T> where T : class
    {
        private readonly IBaseRepository<T> _baseRepository;
        public BaseServices(IBaseRepository<T> baseRepository) 
        {
            _baseRepository = baseRepository;
        }
        #region 查询
        public async Task<T> QueryByID(object objId)
        {
            return await _baseRepository.QueryByID(objId);
        }
        public async Task<List<T>> Query()
        {
            return await _baseRepository.Query();
        }
        public async Task<List<T>> Query(Expression<Func<T, bool>> whereExpression)
        {
            return await _baseRepository.Query(whereExpression);
        }
        public async Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true)
        {
            return await _baseRepository.Query(whereExpression,orderByExpression,isAsc);
        }
        #endregion
        #region 添加
        public async Task<int> Add(T model)
        {
            return await _baseRepository.Add(model);
        }
        #endregion
        #region 删除
        public async Task<bool> DeleteById(object id)
        {
            return await _baseRepository.DeleteById(id);
        }
        public async Task<bool> Delete(T model)
        {
            return await _baseRepository.Delete(model);
        }
        public async Task<bool> DeleteByIds(object[] ids)
        {
            return await _baseRepository.DeleteByIds(ids);
        }
        #endregion
        #region 更新
        public async Task<bool> Update(T model)
        {
            return await _baseRepository.Update(model);
        }
        #endregion
        #region 分页
        public async Task<List<T>> GetPageAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> strWhere, bool isAsc, Expression<Func<T, object>> orderByExpression)
        {
            return await _baseRepository.GetPageAsync(pageIndex,pageSize,strWhere,isAsc,orderByExpression);
        }
        #endregion 
    }
}
