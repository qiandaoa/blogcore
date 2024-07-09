
using Microsoft.EntityFrameworkCore;

namespace Blog.Core.FrameWork
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext>  options) : base(options)
        {
        }

    }
}