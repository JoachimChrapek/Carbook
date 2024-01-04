using Carbook.Domain.Users;

namespace Carbook.Application.Common.Persistence;

public interface IUserRepository
{
    Task AddUserAsync(User user);
    Task<bool> UserExists(string username);
    Task<User?> GetUserByIdAsync(Guid id);
    Task<User?> GetUserByUsernameAsync(string username);
}