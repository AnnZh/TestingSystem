using System;
using TestingSystem.Domain.TestResponses;

namespace TestingSystem.Domain.Tests.Questions
{
    public class VariantOfAnswer
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public Question Question { get; set; }
        public Guid QuestionAnswerId { get; set; }
        public QuestionAnswer QuestionAnswer { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
