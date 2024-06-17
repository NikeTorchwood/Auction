using UsersService.Domain;

namespace UsersService.Services.RepositoriesAbstractions;

public interface IUserRepository
{
    Task<User?> GetUserByEmail(string email);
    Task<User> GetUserByUsername(string username);
    Task Add(User user);
}