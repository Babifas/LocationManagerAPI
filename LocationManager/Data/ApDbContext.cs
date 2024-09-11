using LocationManager.Models;
using Microsoft.EntityFrameworkCore;

namespace LocationManager.Data
{
    public class ApDbContext:DbContext
    {
        public ApDbContext(DbContextOptions<ApDbContext> options):base(options) { }
        public DbSet<Location> Locations { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>(entity =>
            {
                entity.Property(e => e.Latitude)
                    .HasPrecision(9, 6); 

                entity.Property(e => e.Longitude)
                    .HasPrecision(9, 6); 
            });
        }

    }
}
