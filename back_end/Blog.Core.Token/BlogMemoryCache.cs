using Microsoft.Extensions.Caching.Memory;

namespace Blog.Core.Token
{
    // 这个类是一个系统扩张类
    public class BlogMemoryCache
    {
        public static MemoryCache _cache = new MemoryCache(new MemoryCacheOptions());
        /// <summary>
        /// 验证缓存项是否存在
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static bool Exists(string key)
        {
            if (key == null)
            {
                // 没有这个缓存的话给出一个异常
                throw new AggregateException(nameof(key));
            }
            object cached;
            // 尝试获取这个key缓存，并将其存入cahed中 成功为true失败为false
            return _cache.TryGetValue(key, out cached);
        }
        /// <summary>
        /// 获取缓存中Jwt对应的值
        /// </summary>
        /// <param name="key">缓存key</param>
        /// <returns></returns>
        /// <exception cref="AggregateException"></exception>
        public static object Get(string key) 
        {
            if (key == null) 
            {
                throw new AggregateException(nameof(key));
            }
            return _cache.Get(key);
        }
        /// <summary>
        /// 向缓存中添加一个键值对,并设置过期时间
        /// </summary>
        /// <param name="key">键</param>
        /// <param name="value">值</param>
        /// <param name="expiressliding">滑动过期时间,表示从最后一次访问开始到只当时间后该键过期</param>
        /// <param name="expiressAbsoulte">绝对过期时间,表示从添加该键开始,指定时间后会过期</param>
        /// <returns></returns>
        /// <exception cref="AbandonedMutexException"></exception>
        public static bool AddMemoryCache(string key,object value,TimeSpan expiressliding,TimeSpan expiressAbsoulte)
        {
            if (key == null)
            {
                throw new AbandonedMutexException(nameof(key));
            }
            if (value == null) 
            {
                throw new AbandonedMutexException(nameof(value));
            }
            _cache.Set(key, value, new MemoryCacheEntryOptions().SetSlidingExpiration(expiressliding).SetAbsoluteExpiration(expiressAbsoulte));
            return Exists(key);
        }
    }
}
