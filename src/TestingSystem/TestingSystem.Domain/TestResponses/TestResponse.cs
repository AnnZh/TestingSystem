using System;
using System.Collections.Generic;
using TestingSystem.Domain.Tests;
using TestingSystem.Domain.Users;

namespace TestingSystem.Domain.TestResponses
{
    public class TestResponse
    {
        public Guid Id { get; set; }
        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public Guid? UserId { get; set; }
        public User User { get; set; }
        public DateTime PassedDate { get; set; }
        public HashSet<QuestionAnswer> Answers { get; set; }
    }
}
