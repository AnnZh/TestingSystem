using System;
using System.Collections.Generic;

namespace TestingSystem.Domain.Logic.Models.Tests.Questions
{
    public class QuestionDTO
    {
        public Guid Id { get; set; }
        public Guid? TestId { get; set; }
        public string Test { get; set; }
        public string Title { get; set; }
        public byte Number { get; set; }
        public HashSet<VariantOfAnswerDTO> Answers { get; set; }
    }
}
