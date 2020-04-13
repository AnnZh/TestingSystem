using System;
using System.Collections.Generic;
using TestingSystem.Domain.Logic.Models.TestResponses;
using TestingSystem.Domain.Logic.Models.Tests.Questions;

namespace TestingSystem.Domain.Logic.Models.Tests
{
    public class TestDTO
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public Guid? AuthorId { get; set; }
        public string Author { get; set; }
        public Guid? GroupOfTestsId { get; set; }
        public string GroupOfTests { get; set; }
        public DateTime CreatedDate { get; set; }
        public HashSet<QuestionDTO> Questions { get; set; }
        public HashSet<TestResponseDTO> TestResponses { get; set; }
    }
}
