using System;
using System.Collections.Generic;

namespace TestingSystem.Domain.Logic.Models.TestResponses
{
    public class TestResponseDTO
    {
        public Guid Id { get; set; }
        public Guid TestId { get; set; }
        public string Test { get; set; }
        public Guid? UserId { get; set; }
        public string User { get; set; }
        public DateTime PassedDate { get; set; }
        public HashSet<QuestionAnswerDTO> Answers { get; set; }
    }
}
