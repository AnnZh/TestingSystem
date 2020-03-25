using System;
using System.Collections.Generic;
using TestingSystem.Domain.Tests.Questions;

namespace TestingSystem.Domain.TestResponses
{
    public class QuestionAnswer
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public HashSet<VariantOfAnswer> Variants { get; set; }
    }
}
