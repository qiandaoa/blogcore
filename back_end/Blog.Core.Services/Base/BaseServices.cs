using Blog.Core.IRepository.Base;

namespace Blog.Core.Services.Base
{
    public class BaseServices<T> : IBaseRepository<T> where T : class,new()
    {
        
    }
}
