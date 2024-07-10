using Blog.Core.IServices;
using Blog.Core.Model;
using Blog.Core.Services;
using Blog.Core.Token;
using Blog.Core.Token.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Controllers
{
    /// <summary>
    /// post
    /// </summary>
    [Route("api/Blog")]
    [ApiController]
    [Authorize(Policy = "Admin")]
    public class BlogController : Controller
    {
        // GET : api/blog/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        public void Post(string value)
        {
        }
        // PUT: api/Blog/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
        // GET: api/Blog
        /// <summary>
        /// Sum接口
        /// </summary>
        /// <param name="i">参数i</param>
        /// <param name="j">参数j</param>
        /// <returns></returns>
        [HttpGet]
        public int Get(int i, int j)
        {
            IAdvertisementServices advertisementServices = new AdvertisementServices();
            return advertisementServices.Sum(i, j);
        }
    }
}
