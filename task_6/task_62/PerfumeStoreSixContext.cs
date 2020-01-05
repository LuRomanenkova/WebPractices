using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace task_62
{
    public partial class PerfumeStoreSixContext : DbContext
    {
        public PerfumeStoreSixContext()
        {
        }

        public PerfumeStoreSixContext(DbContextOptions<PerfumeStoreSixContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brand> Brands { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Host=localhost;Database=PerfumeStoreSix;Username=postgres;Password=Aa3sdf&");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
