using Blog.Core.IRepository.Base;
using Blog.Core.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.IRepository
{
    public interface IAdvertisementRepository : IBaseRepository<Advertisement>
    {
        //int Sum(int i, int j);
        //int Add(Advertisement model);
        //bool Delete(Advertisement model);
        //bool Update(Advertisement model);
        //// list<Advertisement> 表示可以存放多个Advertisement的对象
        ////Func<Advertisement, bool> 表示一个函数委托，它接受一个 Advertisement 类型的参数并返回一个 bool 类型的结果。
        //// 用于linq查询
        //List<Advertisement> Query(Expression<Func<Advertisement,bool>> whereExpression);
    }
}
