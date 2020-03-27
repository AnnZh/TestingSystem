using Microsoft.EntityFrameworkCore;
using System;
using TestingSystem.Domain.TestResponses;
using TestingSystem.Domain.Tests;
using TestingSystem.Domain.Tests.Questions;
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
        public DbSet<Test> Tests { get; set; }
        public DbSet<GroupOfTests> GroupsOfTests { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<VariantOfAnswer> VariantsOfAnswer { get; set; }
        public DbSet<TestResponse> TestResponses { get; set; }
        public DbSet<QuestionAnswer> QuestionAnswers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<User>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<User>()
                .HasAlternateKey(x => x.Login);
            modelBuilder.Entity<User>()
                .Property(x => x.Login)
                .HasMaxLength(30);
            modelBuilder.Entity<User>()
                .Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<User>()
                .Property(x => x.Surname)
                .IsRequired()
                .HasMaxLength(30);
            modelBuilder.Entity<User>()
                .HasOne(x => x.Role)
                .WithMany()
                .HasForeignKey(x => x.RoleId);
            modelBuilder.Entity<User>()
                .Property(x => x.BirthDate)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.BirthDate)
                .HasConversion(x => x, x => DateTime.SpecifyKind(x, DateTimeKind.Utc));
            modelBuilder.Entity<User>()
                .Property(x => x.RegistrationDate)
                .IsRequired();
            modelBuilder.Entity<User>()
                .Property(x => x.RegistrationDate)
                .HasConversion(x => x, x => DateTime.SpecifyKind(x, DateTimeKind.Utc));

            modelBuilder.Entity<Role>()
                .HasKey(x => x.Id);
            modelBuilder.Entity<Role>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Role>()
                .HasAlternateKey(x => x.Name);
            modelBuilder.Entity<Role>()
                .Property(x => x.Name)
                .HasMaxLength(30);

            modelBuilder.Entity<Test>()
               .HasKey(x => x.Id);
            modelBuilder.Entity<Test>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Test>()
                .Property(x => x.Title)
                .HasMaxLength(60);
            modelBuilder.Entity<Test>()
                .Property(x => x.CreatedDate)
                .IsRequired();
            modelBuilder.Entity<Test>()
                .Property(x => x.CreatedDate)
                .HasConversion(x => x, x => DateTime.SpecifyKind(x, DateTimeKind.Utc));
            modelBuilder.Entity<Test>()
                .HasOne(x => x.Author)
                .WithMany()
                .HasForeignKey(x => x.AuthorId);
            modelBuilder.Entity<Test>()
                .HasOne(x => x.GroupOfTests)
                .WithMany()
                .HasForeignKey(x => x.GroupOfTestsId);
            modelBuilder.Entity<Test>()
                .HasMany(x => x.Questions)
                .WithOne(x => x.Test)
                .HasForeignKey(x => x.TestId);
            modelBuilder.Entity<Test>()
                .HasMany(x => x.TestResponses)
                .WithOne(x => x.Test)
                .HasForeignKey(x => x.TestId);

            modelBuilder.Entity<GroupOfTests>()
               .HasKey(x => x.Id);
            modelBuilder.Entity<GroupOfTests>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<GroupOfTests>()
                .Property(x => x.Name)
                .HasMaxLength(60);

            modelBuilder.Entity<Question>()
               .HasKey(x => x.Id);
            modelBuilder.Entity<Question>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Question>()
                .HasMany(x => x.Answers)
                .WithOne(x => x.Question)
                .HasForeignKey(x => x.QuestionId);

            modelBuilder.Entity<VariantOfAnswer>()
               .HasKey(x => x.Id);
            modelBuilder.Entity<VariantOfAnswer>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<TestResponse>()
               .HasKey(x => x.Id);
            modelBuilder.Entity<TestResponse>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<TestResponse>()
               .Property(x => x.PassedDate)
               .HasConversion(x => x, x => DateTime.SpecifyKind(x, DateTimeKind.Utc));
            modelBuilder.Entity<TestResponse>()
                .Property(x => x.PassedDate)
                .IsRequired();
            modelBuilder.Entity<TestResponse>()
                .HasOne(x => x.User)
                .WithMany()
                .HasForeignKey(x => x.UserId);
            modelBuilder.Entity<TestResponse>()
                .HasMany(x => x.Answers)
                .WithOne(x => x.TestResponse)
                .HasForeignKey(x => x.TestResponseId);

            modelBuilder.Entity<QuestionAnswer>()
               .HasKey(x => x.Id);
            modelBuilder.Entity<QuestionAnswer>()
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<QuestionAnswer>()
                .HasOne(x => x.Question)
                .WithMany()
                .HasForeignKey(x => x.QuestionId);
            modelBuilder.Entity<QuestionAnswer>()
                .HasMany(x => x.Variants)
                .WithOne(x => x.QuestionAnswer)
                .HasForeignKey(x => x.QuestionAnswerId);
        }
    }
}
