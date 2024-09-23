using Microsoft.EntityFrameworkCore;

namespace ServicesSystem.Models
{
    public class LicenseContext: DbContext
    {
        public LicenseContext(DbContextOptions options): base(options)
        {

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<License> Licenses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<License>()
                .HasMany(l => l.Users)
                .WithMany(u => u.Licenses);  // Många-till-många relation
        }
    }

}
