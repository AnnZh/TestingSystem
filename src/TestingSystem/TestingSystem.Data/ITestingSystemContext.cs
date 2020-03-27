using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using TestingSystem.Domain.TestResponses;
using TestingSystem.Domain.Tests;
using TestingSystem.Domain.Tests.Questions;
using TestingSystem.Domain.Users;

namespace TestingSystem.Data
{
    public interface ITestingSystemContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Test> Tests { get; set; }
        public DbSet<GroupOfTests> GroupsOfTests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<VariantOfAnswer> VariantsOfAnswer { get; set; }
        public DbSet<TestResponse> TestResponses { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }
    }
}
