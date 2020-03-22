using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Domain.TestResponses;
using TestingSystem.Domain.Tests.Questions;

namespace TestingSystem.Domain.Tests
{
    public class Test
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual ICollection<Question> Questions { get; set; }
        public virtual ICollection<TestResponse> TestResponses { get; set; }
    }
}
