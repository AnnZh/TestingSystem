using System;
using System.Collections.Generic;

namespace TestingSystem.Domain.Tests.Questions
{
    public class Question
    {
        public Guid Id { get; set; }
        public Guid TestId { get; set; }
        public Test Test { get; set; }
        public string Title { get; set; }
        public byte Number { get; set; }
        public HashSet<VariantOfAnswer> Answers { get; set; }
    }
}
