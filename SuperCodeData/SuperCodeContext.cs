using Microsoft.EntityFrameworkCore;

namespace SuperCodeData
{

    public class SuperCodeContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public SuperCodeContext() : base()
        {

        }

        public SuperCodeContext(DbContextOptions<SuperCodeContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasPartitionKey(o => o.FirstName)
                .OwnsOne(
                    o => o.Location,
                    loc =>
                    {
                        loc.ToJsonProperty("Location");
                        loc.Property(p => p.Id).ToJsonProperty("Id");
                        loc.Property(p => p.Title).ToJsonProperty("Title");
                    });
        }

    }
}
