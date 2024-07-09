using System.Linq.Expressions;
using Blog.Core.IRepository;
using Blog.Core.Model.Models;

namespace Blog.Core.Repository
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        public int Add(Advertisement model)
        {
            throw new NotImplementedException();
        }

        public bool Delete(Advertisement model)
        {
            throw new NotImplementedException();
        }

        public List<Advertisement> Query(Expression<Func<Advertisement, bool>> exp)
        {
            throw new NotImplementedException();
        }

        public int Sum(int i, int j)
        {
            return i+j;
        }

        public bool Update(Advertisement model)
        {
            throw new NotImplementedException();
        }
    }
}