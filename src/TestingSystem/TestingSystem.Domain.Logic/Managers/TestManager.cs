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
using TestingSystem.Domain.Logic.Models.Tests;
using TestingSystem.Domain.Tests;

namespace TestingSystem.Domain.Logic.Managers
{
    public class TestManager : BaseManager, ITestManager
    {
        public TestManager(ITestingSystemContext shopContext, IMapper mapper) : base(shopContext, mapper) { }

        public async Task<TestDTO> CreateTestAsync(TestDTO testDto, CancellationToken token = default)
        {
            var test = _mapper.Map<Test>(testDto);
            await _testingSystemContext.Tests.AddAsync(test);
            await _testingSystemContext.SaveChangesAsync(default);
            return _mapper.Map<TestDTO>(test);
        }

        public async Task DeleteTestByIdAsync(Guid id, CancellationToken token = default)
        {
            var test = await _testingSystemContext.Tests.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);

            if (test is null)
            {
                throw new LogicNullException("This test doesn't exist.");
            }

            _testingSystemContext.Tests.Remove(test);
            await _testingSystemContext.SaveChangesAsync(default);
        }

        public async Task<TestDTO> GetTestByIdAsync(Guid id, CancellationToken token = default)
        {
            var test = await _testingSystemContext.Tests.AsNoTracking().FirstAsync(x => x.Id == id, token);
            if (test is null)
            {
                throw new LogicNullException("This test doesn't exist.");
            }
            return _mapper.Map<TestDTO>(test);
        }

        public async Task<IEnumerable<TestDTO>> GetTestsAsync(CancellationToken token = default)
        {
            var tests = await _testingSystemContext.Tests.Select(test => _mapper.Map<TestDTO>(test)).ToListAsync();

            if (tests == null)
            {
                return Enumerable.Empty<TestDTO>();
            }

            return tests;
        }

        public async Task<TestDTO> UpdateTestAsync(TestDTO testDto, CancellationToken token = default)
        {
            var user = await _testingSystemContext.Tests.FirstAsync(x => x.Id == testDto.Id, token);

            _mapper.Map(testDto, user);
            await _testingSystemContext.SaveChangesAsync(default);

            return testDto;
        }
    }
}
