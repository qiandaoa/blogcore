using Blog.Core.IRepository;
y

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