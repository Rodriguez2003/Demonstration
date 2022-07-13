using Microsoft.EntityFrameworkCore;

namespace Demonstration.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<User> user { get; set; }
    }
}
