namespace Auction.Services.ServicesAbstractions;

public interface IUserHttpClient
{
    Task<bool> CheckReservedEmail(string email);
    Task<bool> CheckReservedUsername(string username);
    Task<bool> RegisterUser(string username, string email, string passwordHash);
}