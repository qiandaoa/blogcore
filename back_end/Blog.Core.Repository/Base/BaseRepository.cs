using Blog.Core.IRepository.Base;


namespace Blog.Core.Repository.Base
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class, new()
    {
    }
}