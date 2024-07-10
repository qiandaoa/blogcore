using Blog.Core.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Blog.Core.Controllers
{
    /// <summary>
    /// post
    /// </summary>
    [Route("api/Blog")]
    [ApiController]
    public class BlogController : Controller
    {
        [HttpGet]
        [Authorize(Policy = "Admin")]
        public IActionResult Get(Love love)
        {
            return Ok(1111);
        }

    }
}
