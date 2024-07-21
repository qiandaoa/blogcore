
using System.Linq.Expressions;

namespace Blog.Core.IRepository.Base
{
        public interface IBaseServices<T> where T : class
        {
        #region 查询

        /// <summary>
        /// 根据ID查询单个实体。
        /// </summary>
        /// <param name="objId">实体ID</param>
        Task<T> QueryByID(object objId);

        /// <summary>
        /// 查询所有实体。
        /// </summary>
        /// <returns>所有实体列表</returns>
        Task<List<T>> Query();

        /// <summary>
        /// 根据表达式查询实体。
        /// </summary>
        /// <param name="whereExpression">查询条件表达式</param>
        /// <returns>符合条件的实体列表</returns>
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression);

        /// <summary>
        /// 根据表达式、排序表达式和排序方式查询实体。
        /// </summary>
        /// <param name="whereExpression">查询条件表达式</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="isAsc">排序方式，true为升序，false为降序</param>
        /// <returns>符合条件的实体列表</returns>
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true);
        #endregion
        #region 添加
        /// <summary>
        /// 添加新的实体。
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>受影响的行数</returns>
        Task<int> Add(T model);
        #endregion
        #region 删除
        /// <summary>
        /// 根据ID删除实体。
        /// </summary>
        /// <param name="id">实体ID</param>
        /// <returns>是否成功删除</returns>
        Task<bool> DeleteById(object id);
        /// <summary>
        /// 删除指定的实体。
        /// </summary>
        /// <param name="model">要删除的实体</param>
        /// <returns>是否成功删除</returns>
        Task<bool> Delete(T model);

        /// <summary>
        /// 根据ID数组删除实体。
        /// </summary>
        /// <param name="ids">实体ID数组</param>
        /// <returns>是否成功删除</returns>
        Task<bool> DeleteByIds(object[] ids);
        #endregion
        #region 更新
        /// <summary>
        /// 更新指定的实体。
        /// </summary>
        /// <param name="model">要更新的实体</param>
        /// <returns>是否成功更新</returns>
        Task<bool> Update(T model);
        #endregion
        #region 分页
        /// <summary>
        /// 分页条件查询
        /// </summary>
        /// <typeparam name="TKey">排序类型</typeparam>
        /// <param name="pageIndex">当前页</param>
        /// <param name="pageSize">每页大小</param>
        /// <param name="predicate">条件表达式</param>
        /// <param name="isAsc">是否升序排列</param>
        /// <param name="keySelector">排序表达式</param>
        /// <returns></returns>
        Task<List<T>> GetPageAsync(int pageIndex, int pageSize, Expression<Func<T, bool>> strWhere, bool isAsc, Expression<Func<T, object>> orderByExpression);
        #endregion
    }
}

