using System;
using System.Collections.Generic;
using TestingSystem.Domain.TestResponses;
using TestingSystem.Domain.Tests.Questions;
using TestingSystem.Domain.Users;

namespace TestingSystem.Domain.Tests
{
    public class Test
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? AuthorId { get; set; }
        public User Author { get; set; }
        public Guid? GroupOfTestsId { get; set; }
        public GroupOfTests GroupOfTests { get; set; }
        public DateTime CreatedDate { get; set; }
        public HashSet<Question> Questions { get; set; }
        public HashSet<TestResponse> TestResponses { get; set; }
    }
}
