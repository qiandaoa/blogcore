using Blog.Core.IRepository.Base;
using Blog.Core.Repository.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.Services.Base
{
    public class BaseServices<T> : IBaseRepository<T> where T : class,new()
    {
        
    }
}
