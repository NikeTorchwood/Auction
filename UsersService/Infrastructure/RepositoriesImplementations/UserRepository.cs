using Microsoft.EntityFrameworkCore;
using UsersService.Domain;
using UsersService.Infrastructure.EntityFramework;
using UsersService.Services.RepositoriesAbstractions;

namespace UsersService.Infrastructure.RepositoriesImplementations;

public class UserRepository(UserDbContext context) : IUserRepository
{
    public async Task<User?> GetUserByEmail(string email)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<User> GetUserByUsername(string username)
    {
        return await context.Users.FirstOrDefaultAsync(u => u.Username == username);
    }

    public async Task Add(User user)
    {
        if (user == null)
        {
            throw new ArgumentNullException(nameof(user));
        }
        else
        {
            await context.AddAsync(user);
            await context.SaveChangesAsync();
        }
    }
}