using Auction.Endpoints;

namespace Auction.Extensions
{
    public  static class ApiExtensions
    {
        public static void AddMappedEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapUsersEndpoints();
        }
    }
}
