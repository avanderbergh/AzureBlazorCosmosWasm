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
    }
}
