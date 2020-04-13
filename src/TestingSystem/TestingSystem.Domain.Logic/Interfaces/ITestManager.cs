using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using TestingSystem.Domain.Logic.Models.Tests;

namespace TestingSystem.Domain.Logic.Interfaces
{
    public interface ITestManager
    {
        Task<TestDTO> CreateTestAsync(TestDTO testDto, CancellationToken token);
        Task<TestDTO> GetTestByIdAsync(Guid id, CancellationToken token);
        Task DeleteTestByIdAsync(Guid id, CancellationToken token);
        Task<IEnumerable<TestDTO>> GetTestsAsync(CancellationToken token);
        Task<TestDTO> UpdateTestAsync(TestDTO testDto, CancellationToken token);
    }
}
