using Blog.Core.Model.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Core.Repository.EFCore
{
    public class BlogContext : DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options) : base(options) 
        { }
        public DbSet<Advertisement> Advertisement { get; set; }
    }
}
