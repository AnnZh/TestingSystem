using System;
using TestingSystem.Domain.Tests.Questions;

namespace TestingSystem.Domain.TestResponses
{
    public class ChoosenVariant
    {
        public Guid Id { get; set; }
        public Guid VariantOfAnswerId { get; set; }
        public VariantOfAnswer VariantOfAnswer { get; set; }
        public Guid QuestionAnswerId { get; set; }
        public QuestionAnswer QuestionAnswer { get; set; }
    }
}
