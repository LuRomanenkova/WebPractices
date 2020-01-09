using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace task_7.Models
{
    public class PerfumeStoreContext : DbContext
    {
        public DbSet<Perfume> Perfumes { get; set; }
        public DbSet<Brand> Brands { get; set; }

        public PerfumeStoreContext(DbContextOptions<PerfumeStoreContext> options)
            : base(options)
        {
            //Database.EnsureCreated();
        }
    }
}
