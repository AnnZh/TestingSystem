﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using TestingSystem.Data;

namespace TestingSystem.Data.Migrations
{
    [DbContext(typeof(TestingSystemContext))]
    [Migration("20200331163634_addAllTables")]
    partial class addAllTables
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("TestingSystem.Domain.TestResponses.ChoosenVariant", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionAnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("VariantOfAnswerId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionAnswerId");

                    b.HasIndex("VariantOfAnswerId");

                    b.ToTable("ChoosenVariants");
                });

            modelBuilder.Entity("TestingSystem.Domain.TestResponses.QuestionAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TestResponseId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.HasIndex("TestResponseId");

                    b.ToTable("QuestionAnswers");
                });

            modelBuilder.Entity("TestingSystem.Domain.TestResponses.TestResponse", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("PassedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("TestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.HasIndex("UserId");

                    b.ToTable("TestResponses");
                });

            modelBuilder.Entity("TestingSystem.Domain.Tests.GroupOfTests", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.ToTable("GroupsOfTests");
                });

            modelBuilder.Entity("TestingSystem.Domain.Tests.Questions.Question", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<byte>("Number")
                        .HasColumnType("tinyint");

                    b.Property<Guid?>("TestId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("TestId");

                    b.ToTable("Questions");
                });

            modelBuilder.Entity("TestingSystem.Domain.Tests.Questions.VariantOfAnswer", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsCorrect")
                        .HasColumnType("bit");

                    b.Property<Guid?>("QuestionId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Text")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("QuestionId");

                    b.ToTable("VariantsOfAnswer");
                });

            modelBuilder.Entity("TestingSystem.Domain.Tests.Test", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("AuthorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("GroupOfTestsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Title")
                        .HasColumnType("nvarchar(60)")
                        .HasMaxLength(60);

                    b.HasKey("Id");

                    b.HasIndex("AuthorId");

                    b.HasIndex("GroupOfTestsId");

                    b.ToTable("Tests");
                });

            modelBuilder.Entity("TestingSystem.Domain.Users.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasAlternateKey("Name");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("TestingSystem.Domain.Users.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Surname")
                        .IsRequired()
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.HasKey("Id");

                    b.HasAlternateKey("Login");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("TestingSystem.Domain.TestResponses.ChoosenVariant", b =>
                {
                    b.HasOne("TestingSystem.Domain.TestResponses.QuestionAnswer", "QuestionAnswer")
                        .WithMany("Variants")
                        .HasForeignKey("QuestionAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestingSystem.Domain.Tests.Questions.VariantOfAnswer", "VariantOfAnswer")
                        .WithMany()
                        .HasForeignKey("VariantOfAnswerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestingSystem.Domain.TestResponses.QuestionAnswer", b =>
                {
                    b.HasOne("TestingSystem.Domain.Tests.Questions.Question", "Question")
                        .WithMany()
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestingSystem.Domain.TestResponses.TestResponse", "TestResponse")
                        .WithMany("Answers")
                        .HasForeignKey("TestResponseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("TestingSystem.Domain.TestResponses.TestResponse", b =>
                {
                    b.HasOne("TestingSystem.Domain.Tests.Test", "Test")
                        .WithMany("TestResponses")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("TestingSystem.Domain.Users.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("TestingSystem.Domain.Tests.Questions.Question", b =>
                {
                    b.HasOne("TestingSystem.Domain.Tests.Test", "Test")
                        .WithMany("Questions")
                        .HasForeignKey("TestId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("TestingSystem.Domain.Tests.Questions.VariantOfAnswer", b =>
                {
                    b.HasOne("TestingSystem.Domain.Tests.Questions.Question", "Question")
                        .WithMany("Answers")
                        .HasForeignKey("QuestionId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("TestingSystem.Domain.Tests.Test", b =>
                {
                    b.HasOne("TestingSystem.Domain.Users.User", "Author")
                        .WithMany()
                        .HasForeignKey("AuthorId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.HasOne("TestingSystem.Domain.Tests.GroupOfTests", "GroupOfTests")
                        .WithMany()
                        .HasForeignKey("GroupOfTestsId")
                        .OnDelete(DeleteBehavior.SetNull);
                });

            modelBuilder.Entity("TestingSystem.Domain.Users.User", b =>
                {
                    b.HasOne("TestingSystem.Domain.Users.Role", "Role")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}