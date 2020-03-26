using AutoMapper;
using TestingSystem.Data;
using TestingSystem.Domain.Logic.Interfaces;

namespace TestingSystem.Domain.Logic.Managers
{
    public class UserManager : IUserManager
    {
        private readonly ITestingSystemContext _testingSystemContext;
        private readonly IMapper _mapper;

        public UserManager(ITestingSystemContext shopContext, IMapper mapper)
        {
            _testingSystemContext = shopContext;
            _mapper = mapper;
        }
    }
}
