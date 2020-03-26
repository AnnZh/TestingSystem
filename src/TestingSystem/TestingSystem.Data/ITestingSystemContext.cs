using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TestingSystem.Domain.Users;

namespace TestingSystem.Data
{
    public interface ITestingSystemContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
    }
}
