using Microsoft.EntityFrameworkCore;

namespace AspNetCore_Configuration_BestPractice.Database
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            :base(options)
        {

        }
        public DbSet<User> Users { get; set; }
    }
}
