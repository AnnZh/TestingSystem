using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using TestingSystem.Data;
using TestingSystem.Domain.Logic.Exceptions;
using TestingSystem.Domain.Logic.Interfaces;
using TestingSystem.Domain.Logic.Models.Users;
using TestingSystem.Domain.Users;

namespace TestingSystem.Domain.Logic.Managers
{
    public class UserManager : BaseManager, IUserManager
    {
        private readonly IPasswordHasher<User> _passwordHasher;

        public UserManager(ITestingSystemContext shopContext, IMapper mapper, IPasswordHasher<User> passwordHasher) 
            : base(shopContext, mapper)
        {
            _passwordHasher = passwordHasher;
        }

        public async Task DeleteUserByIdAsync(Guid id, CancellationToken token = default)
        {
            var user = await _testingSystemContext.Users.IgnoreQueryFilters().FirstOrDefaultAsync(x => x.Id == id);

            if (user is null)
            {
                throw new LogicNullException("This user doesn't exist.");
            }

            _testingSystemContext.Users.Remove(user);
            await _testingSystemContext.SaveChangesAsync(token);
        }

        public async Task<UserDTO> GetUserByIdAsync(Guid id, CancellationToken token = default)
        {
            var user = await _testingSystemContext.Users.AsNoTracking().FirstAsync(x => x.Id == id, token);
            if (user is null)
            {
                throw new LogicNullException("This user doesn't exist.");
            }
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> GetUserByLoginAsync(string login, CancellationToken token = default)
        {
            var user = await _testingSystemContext.Users.AsNoTracking().FirstAsync(x => x.Login == login, token);
            if (user is null)
            {
                throw new LogicNullException("User with this login doesn't exist.");
            }
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> SignInAsync(UserDTO userDto, CancellationToken token = default)
        {
            var user = _mapper.Map<User>(await GetUserByLoginAsync(userDto.Login));

            var result = _passwordHasher.VerifyHashedPassword(user, user.Password, userDto.Password);
            if (result == PasswordVerificationResult.Failed)
            {
                throw new LogicException("Incorrect password.");
            }

            return _mapper.Map<UserDTO>(user); 
        }

        public async Task<UserDTO> SignUpAsync(UserDTO userDto, CancellationToken token = default)
        {
            if (await _testingSystemContext.Users.AnyAsync(u => u.Login == userDto.Login))
            {
                throw new LogicException("User with this login already exists.");
            }

            var user = _mapper.Map<User>(userDto);
            user.Password = _passwordHasher.HashPassword(user, userDto.Password);
            user.RoleId = (await _testingSystemContext.Roles.FirstOrDefaultAsync(r => r.Name == "User")).Id;
            await _testingSystemContext.Users.AddAsync(user);
            await _testingSystemContext.SaveChangesAsync(token);
            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateProfileAsync(UserDTO userDto, CancellationToken token = default)
        {
            var user = await _testingSystemContext.Users.FirstAsync(x => x.Id == userDto.Id, token);

            _mapper.Map(userDto, user);
            await _testingSystemContext.SaveChangesAsync(token);

            return userDto;
        }
    }
}
