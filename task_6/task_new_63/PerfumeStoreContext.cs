using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace task_new_63
{
    public class PerfumeStoreContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Perfume> Perfumes { get; set; }
        public PerfumeStoreContext()
        {
            //    Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Database=PerfumeStoreNew63;Username=postgres;Password=Aa3sdf&;");
        }
    }
}
