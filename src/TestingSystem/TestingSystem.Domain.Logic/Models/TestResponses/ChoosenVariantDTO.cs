using System;
using TestingSystem.Domain.Logic.Models.Tests.Questions;

namespace TestingSystem.Domain.Logic.Models.TestResponses
{
    public class ChoosenVariantDTO
    {
        public Guid Id { get; set; }
        public Guid VariantOfAnswerId { get; set; }
        public VariantOfAnswerDTO VariantOfAnswer { get; set; }
        public Guid QuestionAnswerId { get; set; }
    }
}
