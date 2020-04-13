using System;
using System.Collections.Generic;

namespace TestingSystem.Domain.Logic.Models.TestResponses
{
    public class QuestionAnswerDTO
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string Question { get; set; }
        public Guid TestResponseId { get; set; }
        public HashSet<ChoosenVariantDTO> Variants { get; set; }
    }
}
