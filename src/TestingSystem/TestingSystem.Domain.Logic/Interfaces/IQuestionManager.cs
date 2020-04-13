using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestingSystem.Domain.Logic.Models.Tests.Questions;

namespace TestingSystem.Domain.Logic.Interfaces
{
    public interface IQuestionManager
    {
        Task<QuestionDTO> CreateQuestionAsync(QuestionDTO questionDto, CancellationToken token);
        Task<QuestionDTO> GetQuestionByIdAsync(Guid id, CancellationToken token);
        Task DeleteQuestionByIdAsync(Guid id, CancellationToken token);
        Task<IEnumerable<QuestionDTO>> GetQuestionsAsync(CancellationToken token);
        Task<QuestionDTO> UpdateQuestionAsync(QuestionDTO questionDto, CancellationToken token);
    }
}
