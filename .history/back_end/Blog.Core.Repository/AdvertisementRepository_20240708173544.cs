using Blog.Core.IRepository;
using Blog.Core.Model;

namespace Blog.Core.Repository
{
    public class AdvertisementRepository : IAdvertisementRepository
    {
        public int Sum(int i, int j)
        {
            return i+j;
        }
    }
}