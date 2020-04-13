using System;

namespace TestingSystem.Domain.Logic.Models.Tests.Questions
{
    public class VariantOfAnswerDTO
    {
        public Guid Id { get; set; }
        public Guid? QuestionId { get; set; }
        public string Text { get; set; }
        public bool IsCorrect { get; set; }
    }
}
