using Microsoft.EntityFrameworkCore;

namespace SuperCodeData
{

    public class LocationContext : DbContext
    {
        public DbSet<Location> Locations { get; set; }
        public DbSet<User> Users { get; set; }

        public LocationContext() : base()
        {

        }

        public LocationContext(DbContextOptions<LocationContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Location>().HasPartitionKey(l => l.LocationId);
            modelBuilder.Entity<User>().HasPartitionKey(o => o.LocationId).HasOne(u => u.Location).WithMany(l => l.Users);
        }

    }
}
