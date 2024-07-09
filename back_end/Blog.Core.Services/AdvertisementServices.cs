using System.Linq.Expressions;
using Blog.Core.FrameWork;
using Blog.Core.IRepository;
using Blog.Core.IServices;
using Blog.Core.Model.Models;
using Blog.Core.Repository;

namespace Blog.Core.Services
{
    public class AdvertisementServices : IAdvertisementServices
    {
        public IAdvertisementRepository dal;

        public AdvertisementServices(AdvertisementRepository advertisementRepository)
        {
            dal = advertisementRepository;
        }
        // public IAdvertisementRepository dal = new AdvertisementRepository();
        public int Sum(int i, int j)
        {
            return dal.Sum(i,j);
        }
        public int Add(Advertisement model)
        {
            return dal.Add(model);
        }
        public bool Delete(Advertisement model)
        {
            return dal.Delete(model);
        }
        public List<Advertisement> Query(Expression<Func<Advertisement, bool>> whereExpression)
        {
            return dal.Query(whereExpression);
        }
        public bool Update(Advertisement model)
        {
            return dal.Update(model);
        }
    }
}