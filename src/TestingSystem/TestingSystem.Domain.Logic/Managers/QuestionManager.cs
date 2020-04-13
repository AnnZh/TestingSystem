using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using TestingSystem.Data;
using TestingSystem.Domain.Logic.Exceptions;
using TestingSystem.Domain.Logic.Interfaces;
using TestingSystem.Domain.Logic.Models.Tests.Questions;
using TestingSystem.Domain.Tests.Questions;

namespace TestingSystem.Domain.Logic.Managers
{
    public class QuestionManager : BaseManager, IQuestionManager
    {
        public QuestionManager(ITestingSystemContext shopContext, IMapper mapper) : base(shopContext, mapper) { }

        public async Task<QuestionDTO> CreateQuestionAsync(QuestionDTO questionDto, CancellationToken token)
        {
            var question = _mapper.Map<Question>(questionDto);
            await _testingSystemContext.Questions.AddAsync(question);
            await _testingSystemContext.SaveChangesAsync(token);
            return _mapper.Map<QuestionDTO>(question);
        }

        public async Task DeleteQuestionByIdAsync(Guid id, CancellationToken token = default)
        {
            var question = await _testingSystemContext.Questions.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);

            if (question is null)
            {
                throw new LogicNullException("This question doesn't exist.");
            }

            _testingSystemContext.Questions.Remove(question);
            await _testingSystemContext.SaveChangesAsync(token);
        }

        public async Task<QuestionDTO> GetQuestionByIdAsync(Guid id, CancellationToken token = default)
        {
            var question = await _testingSystemContext.Questions.AsNoTracking().FirstAsync(x => x.Id == id, token);
            if (question is null)
            {
                throw new LogicNullException("This question doesn't exist.");
            }
            return _mapper.Map<QuestionDTO>(question);
        }

        public async Task<IEnumerable<QuestionDTO>> GetQuestionsAsync(CancellationToken token = default)
        {
            var questions = await _testingSystemContext.Questions.Select(question => _mapper.Map<QuestionDTO>(question)).ToListAsync();

            if (questions == null)
            {
                return Enumerable.Empty<QuestionDTO>();
            }

            return questions;
        }

        public async Task<QuestionDTO> UpdateQuestionAsync(QuestionDTO questionDto, CancellationToken token = default)
        {
            var user = await _testingSystemContext.Questions.FirstAsync(x => x.Id == questionDto.Id, token);

            _mapper.Map(questionDto, user);
            await _testingSystemContext.SaveChangesAsync(token);

            return questionDto;
        }
    }
}
