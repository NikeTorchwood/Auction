using UsersService.Controllers;

namespace UsersService.Services.ServicesAbstractions;

public interface IUserService
{
    Task<bool> CheckReservedEmail(string email);
    Task<bool> CheckReservedUsername(string username);

    Task RegisterUser(UserCreateDto createDto);
}