using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Domain.Tests.Questions
{
    public class Question
    {
        public string Id { get; set; }
        public string TestId { get; set; }
        public Test Test { get; set; }
        public string Title { get; set; }
        public byte Number { get; set; }
        public virtual ICollection<VariantOfAnswer> Answers { get; set; }
    }
}
