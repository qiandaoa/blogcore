using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Blog.Core.IServices.Base
{
    public interface IBaseServices<T> where T : class
    {
        Task<T> GetById(int Id);
        Task<List<T>> GetByIds();
        Task<T> Add(T model);
        Task<bool> DeleteById(int Id);
        Task<bool> Update(T model);
        Task<List<T>> Query(string strWhere);
    }
}