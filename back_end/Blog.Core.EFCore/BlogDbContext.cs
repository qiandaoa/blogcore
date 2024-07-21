using Blog.Core.Model.Models;
using Microsoft.EntityFrameworkCore;
namespace Blog.Core.EFCore
{
    public class BlogDbContext : DbContext
    {
        public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
        { }
        public DbSet<Advertisement> advertisements { get; set; }
    }
}
