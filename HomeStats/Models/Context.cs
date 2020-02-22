using Microsoft.EntityFrameworkCore;

namespace HomeStats.Models
{
    public class Context : DbContext
    {
        public DbSet<House> Houses { get; set; }

        public Context(DbContextOptions<Context> options) :base(options)
        {
            Database.EnsureCreated();
        }
    }
}
