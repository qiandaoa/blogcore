using System.Linq.Expressions;
using Blog.Core.FrameWork;
using Blog.Core.IRepository.Base;
using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private BlogDbContext _db;
        public BaseRepository(BlogDbContext db)
        {
            _db = db;
        }

        public async Task<T> Add(T model)
        {
            await _db.Set<T>().AddAsync(model);
            await _db.SaveChangesAsync();
            return model;
        }
        public async Task<bool> DeleteById(int Id)
        {
            var model = await _db.Set<T>().FindAsync(Id);
            if (model != null)
            {
                _db.Set<T>().Remove(model);
                await _db.SaveChangesAsync();
                return true;
            }
            return false;
        }
        public async Task<T> GetById(int Id)
        {
            var model =  await _db.Set<T>().FindAsync(Id);
            return model;

        }

        public async Task<List<T>> GetByIds()
        {
            return await _db.Set<T>().ToListAsync();
        }

        public Task<List<T>> Query(string strWhere)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(T model)
        {
            _db.Set<T>().Update(model);
            return await _db.SaveChangesAsync() > 0;
        }
    }
}