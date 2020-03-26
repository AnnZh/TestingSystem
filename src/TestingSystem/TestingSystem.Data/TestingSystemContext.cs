using Microsoft.EntityFrameworkCore;
using TestingSystem.Domain.Users;

namespace TestingSystem.Data
{
    public class TestingSystemContext : DbContext, ITestingSystemContext
    {
        public TestingSystemContext(DbContextOptions<TestingSystemContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();


            modelBuilder.Entity<Role>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Role>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
