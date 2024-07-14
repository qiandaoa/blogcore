using Blog.Core.Model.Models;
using Blog.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Data
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) { }
        public DbSet<Advertisement> advertisements { get; set; }
    }
}
