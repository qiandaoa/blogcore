using System.Linq.Expressions;

namespace Blog.Core.IRepository.Base
{
    public interface IBaseRepository<T> where T : class
    {
        #region 查询
        /// <summary>
        /// 根据ID查询单个实体。
        /// </summary>
        /// <param name="objId">实体ID</param>
        /// <returns>查询到的实体</returns>
        Task<T> QueryByID(object objId);

        /// <summary>
        /// 根据ID查询单个实体，可选使用缓存。
        /// </summary>
        /// <param name="objId">实体ID</param>
        /// <param name="blnUseCache">是否使用缓存，默认为false</param>
        /// <returns>查询到的实体</returns>
        Task<T> QueryByID(object objId, bool blnUseCache = false);

        /// <summary>
        /// 根据ID数组查询多个实体。
        /// </summary>
        /// <param name="lstIds">实体ID数组</param>
        /// <returns>查询到的实体列表</returns>
        Task<List<T>> QueryByIDs(object[] lstIds);
        /// <summary>
        /// 查询所有实体。
        /// </summary>
        /// <returns>所有实体列表</returns>
        Task<List<T>> Query();

        /// <summary>
        /// 根据条件语句查询实体。
        /// </summary>
        /// <param name="strWhere">查询条件语句</param>
        /// <returns>符合条件的实体列表</returns>
        Task<List<T>> Query(string strWhere);

        /// <summary>
        /// 根据表达式查询实体。
        /// </summary>
        /// <param name="whereExpression">查询条件表达式</param>
        /// <returns>符合条件的实体列表</returns>
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression);

        /// <summary>
        /// 根据表达式、排序字段和排序方式查询实体。
        /// </summary>
        /// <param name="whereExpression">查询条件表达式</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns>符合条件的实体列表</returns>
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, string strOrderByFileds);

        /// <summary>
        /// 根据表达式、排序表达式和排序方式查询实体。
        /// </summary>
        /// <param name="whereExpression">查询条件表达式</param>
        /// <param name="orderByExpression">排序表达式</param>
        /// <param name="isAsc">排序方式，true为升序，false为降序</param>
        /// <returns>符合条件的实体列表</returns>
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, Expression<Func<T, object>> orderByExpression, bool isAsc = true);

        /// <summary>
        /// 根据条件语句和排序字段查询实体。
        /// </summary>
        /// <param name="strWhere">查询条件语句</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns>符合条件的实体列表</returns>
        Task<List<T>> Query(string strWhere, string strOrderByFileds);

        /// <summary>
        /// 根据表达式、排序字段和页码查询实体。
        /// </summary>
        /// <param name="whereExpression">查询条件表达式</param>
        /// <param name="intTop">返回记录数</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns>符合条件的实体列表</returns>
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intTop, string strOrderByFileds);

        /// <summary>
        /// 根据条件语句、页码和排序字段查询实体。
        /// </summary>
        /// <param name="strWhere">查询条件语句</param>
        /// <param name="intTop">返回记录数</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns>符合条件的实体列表</returns>
        Task<List<T>> Query(string strWhere, int intTop, string strOrderByFileds);

        /// <summary>
        /// 根据表达式、页码、页大小和排序字段查询实体。
        /// </summary>
        /// <param name="whereExpression">查询条件表达式</param>
        /// <param name="intPageIndex">页码</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns>符合条件的实体列表</returns>
        Task<List<T>> Query(Expression<Func<T, bool>> whereExpression, int intPageIndex, int intPageSize, string strOrderByFileds);

        /// <summary>
        /// 根据条件语句、页码、页大小和排序字段查询实体。
        /// </summary>
        /// <param name="strWhere">查询条件语句</param>
        /// <param name="intPageIndex">页码</param>
        /// <param name="intPageSize">页大小</param>
        /// <param name="strOrderByFileds">排序字段</param>
        /// <returns>符合条件的实体列表</returns>
        Task<List<T>> Query(string strWhere, int intPageIndex, int intPageSize, string strOrderByFileds);

        /// <summary>
        /// 根据表达式和可选参数查询实体分页数据。
        /// </summary>
        /// <param name="whereExpression">查询条件表达式</param>
        /// <param name="intPageIndex">页码，默认为0</param>
        /// <param name="intPageSize">页大小，默认为20</param>
        /// <param name="strOrderByFileds">排序字段，默认为null</param>
        /// <returns>符合条件的实体列表</returns>
        Task<List<T>> QueryPage(Expression<Func<T, bool>> whereExpression, int intPageIndex = 0, int intPageSize = 20, string strOrderByFileds = null);
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

        /// <summary>
        /// 根据实体和条件语句更新实体。
        /// </summary>
        /// <param name="entity">要更新的实体</param>
        /// <param name="strWhere">更新条件语句</param>
        /// <returns>是否成功更新</returns>
        Task<int> Update(Expression<Func<T, bool>> strWhere, Expression<Func<T, T>> entity);
        #endregion
    }
}
