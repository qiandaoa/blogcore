using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Core.EFCore
{
    public class DbContextDesignTimeFactory : IDesignTimeDbContextFactory<BlogDbContext>
    {
        public BlogDbContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<BlogDbContext> builder = new DbContextOptionsBuilder<BlogDbContext>();
            builder.UseNpgsql("host=101.133.150.189;port=5432;database=blog;uid=blog;pwd=2071260354");
            return new BlogDbContext(builder.Options);
              
        }
    }
}
