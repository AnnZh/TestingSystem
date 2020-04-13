using AutoMapper;
using TestingSystem.Data;

namespace TestingSystem.Domain.Logic.Managers
{
    public class BaseManager
    {
        protected readonly ITestingSystemContext _testingSystemContext;
        protected readonly IMapper _mapper;
        protected BaseManager(ITestingSystemContext shopContext, IMapper mapper)
        {
            _testingSystemContext = shopContext;
            _mapper = mapper;
        }
    }
}
