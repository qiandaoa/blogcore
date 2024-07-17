
using Blog.Core.IServices;
using Blog.Core.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Controllers
{
    [Produces("application/json")]
    [Route("api/Blog")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class BlogController : Controller
    {
        private readonly Iservices _services;
        public BlogController(Iservices iservices)
        {
            _services = iservices;
         }
        [HttpPost]
        public ActionResult<int> num(int i, int j)
        {
            return _services.Number(i, j);
        }
        // GET: api/Blog/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
    }
}
