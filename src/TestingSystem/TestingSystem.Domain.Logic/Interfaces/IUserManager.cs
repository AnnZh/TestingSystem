using System;
using System.Threading;
using System.Threading.Tasks;
using TestingSystem.Domain.Logic.Models.Users;

namespace TestingSystem.Domain.Logic.Interfaces
{
    public interface IUserManager
    {
        Task<UserDTO> SignUpAsync(UserDTO userDto, CancellationToken token);
        Task<UserDTO> SignInAsync(UserDTO userDto, CancellationToken token);
        Task<UserDTO> GetUserByIdAsync(Guid id, CancellationToken token);
        Task<UserDTO> GetUserByLoginAsync(string login, CancellationToken token);
        Task<UserDTO> UpdateProfileAsync(UserDTO userDto, CancellationToken token);
        Task DeleteUserByIdAsync(Guid id, CancellationToken token);
    }
}
