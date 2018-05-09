using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WADTestApp2.Model
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public ApplicationDbContext(DbContextOptions options)
            :base(options)
        {
        }
    }
}
