namespace Auction.Services.ServicesAbstractions;

public interface IUserService
{
    Task<(bool, string)> Register(string username, string email, string password);
}