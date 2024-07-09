using Blog.Core.IServices;
using Blog.Core.Model.Models;
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
        private readonly IAdvertisementServices _ad;
        public BlogController(IAdvertisementServices advertisementServices)
        {
            _ad = advertisementServices;
        }
        [HttpGet]
        public int Get(int i,int j)
        {
            return _ad.Sum(i,j);
        }
        [HttpGet("{id}")]
        public List<Advertisement> Get(int id)
        {
            return _ad.Query(item=>item.Id==id).ToList();
        }
    }
}