using System;
using System.Collections.Generic;
using System.Text;

namespace TestingSystem.Domain.Tests.Questions
{
    public class VariantOfAnswer
    {
        public string Id { get; set; }
        public string QuestionId { get; set; }
        public Question Question { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
