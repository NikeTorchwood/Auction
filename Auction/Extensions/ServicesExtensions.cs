using Auction.Infrastructure.Hasher;
using Auction.Services.ServicesAbstractions;
using Auction.Services.ServicesImplementations;
namespace Auction.Extensions
{
    public static class ServicesExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.InstallServices();
            return services;
        }
        private static IServiceCollection InstallServices(this IServiceCollection services)
        {
            services.AddScoped<IPasswordHasher, PasswordHasher>();
            services.AddScoped<IUserService, UserService>();
            services.AddHttpClient();
            services.AddScoped<IUserHttpClient, UserHttpClient>();
            return services;
        }
    }
}
