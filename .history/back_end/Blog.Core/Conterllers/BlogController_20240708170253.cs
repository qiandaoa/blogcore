using Blog.Core.IServices;
using Blog.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Conterllers
{
    /// <summary>
    /// 博客管理
    /// </summary>
    [Route("[controller]")]
    public class BlogController : ControllerBase
    {
        [HttpGet]
        public int Get(int i,int j)
        {
            IAdvertisementServices advertisementServices = new AdvertisementServices();
        }
    }
}