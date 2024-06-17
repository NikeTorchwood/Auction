using UsersService.Controllers;
using UsersService.Domain;
using UsersService.Services.RepositoriesAbstractions;
using UsersService.Services.ServicesAbstractions;

namespace UsersService.Services.ServicesImplementations
{
    public class UserService(IUserRepository repository) : IUserService
    {

        public async Task<bool> CheckReservedEmail(string email)
        {
            var user = await repository.GetUserByEmail(email);
            return user != null;
        }

        public async Task<bool> CheckReservedUsername(string username)
        {
            var user = await repository.GetUserByUsername(username);
            return user != null;
        }

        public async Task RegisterUser(UserCreateDto createDto)
        {
            var user = new User()
            {
                Username = createDto.Username,
                Email = createDto.Email,
                PasswordHash = createDto.PasswordHash
            };
            await repository.Add(user);
            
        }
    }
}
