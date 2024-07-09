using Blog.Core.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Core.FrameWork
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext>  options) : base(options)
        {
        }
        public DbSet<Advertisement> Advertisements {get;set;}
    }
}