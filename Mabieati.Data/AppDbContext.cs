using Mabieati.Data.Configurations;
using Mabieati.Kernel.Models;
using Microsoft.EntityFrameworkCore;

namespace Mabieati.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base()
        {

        }

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConfigurationsMarker).Assembly);
            base.OnModelCreating(modelBuilder);
        }
    }
}
