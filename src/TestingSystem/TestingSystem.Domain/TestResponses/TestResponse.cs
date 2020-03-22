using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Domain.Tests;

namespace TestingSystem.Domain.TestResponses
{
    public class TestResponse
    {
        public string Id { get; set; }
        public string TestId { get; set; }
        public Test Test { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public DateTime PassedDate { get; set; }
        public virtual ICollection<QuestionAnswer> Answers { get; set; }
    }
}
