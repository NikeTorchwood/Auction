using Auction.Infrastructure.Hasher;
using Auction.Services.ServicesAbstractions;

namespace Auction.Services.ServicesImplementations
{
    public class UserService(IUserHttpClient client, IPasswordHasher hasher) : IUserService
    {
        public async Task<(bool, string)> Register(string username, string email, string password)
        {
            var emailIsReserved = await client.CheckReservedEmail(email);
            if (emailIsReserved)
            {
                return (false, "Email is Reserved");
            }
            var usernameIsReserved = await client.CheckReservedUsername(username);
            if (usernameIsReserved)
            {
                return (false, "Username is Reserved");
            }

            var passwordHash = hasher.Generate(password);

            var isRegistered = await client.RegisterUser(username, email, passwordHash);
            return isRegistered ? (true, "User was registered") : (false, "Unknown exception");
        }
    }
}
