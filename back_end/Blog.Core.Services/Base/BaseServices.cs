using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blog.Core.IRepository.Base;

namespace Blog.Core.Services.Base
{
    public class BaseServices<T> : IBaseRepository<T> where T : class
    {
        public IBaseRepository<T> _db;

        public BaseServices(IBaseRepository<T> baseRepository)
        {
            _db  = baseRepository;
        }
        public async Task<T> Add(T model)
        {
            return await _db.Add(model);
        }
        public async Task<bool> DeleteById(int Id)
        {
            return await _db.DeleteById(Id);
        }
        public async Task<T> GetById(int Id)
        {
            return await _db.GetById(Id);
        }

        public async Task<List<T>> GetByIds()
        {
            return await _db.GetByIds();
        }

        public Task<List<T>> Query(string strWhere)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(T model)
        {
            return await _db.Update(model);
        }
    }
}