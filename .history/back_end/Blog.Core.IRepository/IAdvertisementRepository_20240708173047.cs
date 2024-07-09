
using Blog.Core.Model.Models;

namespace Blog.Core.IRepository
{
    public interface IAdvertisementRepository
    {
        int Sum(int i,int j);
        int Add(Advertisement model);
        bool Delete(Advertisement model);
    }
}