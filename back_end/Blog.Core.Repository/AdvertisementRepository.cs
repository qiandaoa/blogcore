using System.Linq.Expressions;
using Blog.Core.IRepository;
using Blog.Core.Model.Models;
using Blog.Core.FrameWork;
namespace Blog.Core.Repository
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        private BlogDbContext _db;
        public AdvertisementRepository(BlogDbContext db)
        {
            _db = db;
        }
        public int Add(Advertisement model)
        {
            var i = _db.Set<Advertisement>().Add(model);
            return i.Entity.Id;
        }

        public bool Delete(Advertisement model)
        {
            var i = _db.Set<Advertisement>().Remove(model);
            return i.Entity.Id > 0;
        }

        public List<Advertisement> Query(Expression<Func<Advertisement, bool>> exp)
        {
            return _db.Set<Advertisement>().Where(exp).ToList();
        }

        public int Sum(int i, int j)
        {
            return i+j;
        }

        public bool Update(Advertisement model)
        {
            var i = _db.Set<Advertisement>().Update(model);
            return i.Entity.Id > 0;
        }
    }
}