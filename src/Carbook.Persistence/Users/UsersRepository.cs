using Carbook.Application.Common.Persistence;
using Carbook.Domain.Users;
using Microsoft.EntityFrameworkCore;

namespace Carbook.Persistence.Users;

public class UsersRepository : IUserRepository
{
    private readonly CarbookDbContext _carbookDbContext;

    public UsersRepository(CarbookDbContext carbookDbContext)
    {
        _carbookDbContext = carbookDbContext;
    }
    
    public async Task AddUserAsync(User user)
    {
        await _carbookDbContext.Users.AddAsync(user);
        await _carbookDbContext.SaveChangesAsync();
    }

    public async Task<bool> UserExists(string username)
    {
        return await _carbookDbContext.Users.AnyAsync(u => u.Username == username);
    }

    public async Task<User?> GetUserByIdAsync(Guid id)
    {
        return await _carbookDbContext.Users.FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetUserByUsernameAsync(string username)
    {
        return await _carbookDbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
    }
}