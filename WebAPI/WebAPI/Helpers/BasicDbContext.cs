using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(p => p.Id);
        }

        public DbSet<User> Users { get; set; }
    }
}
