using System;
using System.Collections.Generic;
using System.Text;
using TestingSystem.Domain.Tests.Questions;

namespace TestingSystem.Domain.TestResponses
{
    public class QuestionAnswer
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public Question Question { get; set; }
        public virtual ICollection<VariantOfAnswer> Variants { get; set; }
    }
}
