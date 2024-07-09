using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Blog.Core.IRepository.Base
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetById(int Id);
        Task<List<T>> GetByIds();
        Task<T>  Add(T model);
        Task<bool> DeleteById(int Id);
        Task<bool> Update(T model);
        Task<List<T>> Query(string strWhere);
    }
}