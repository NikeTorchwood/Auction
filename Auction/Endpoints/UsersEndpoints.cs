using Auction.Contracts.Users;
using Auction.Services.ServicesAbstractions;
using Microsoft.AspNetCore.Mvc;

namespace Auction.Endpoints
{
    public static class UsersEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            var usersEnpoints = app.MapGroup("api/users");
            usersEnpoints.MapPost("register", Register);

            return app;
        }

        private static async Task<IResult> Register([FromBody] RegisterUserRequest request, IUserService userService, HttpContext context)
        {
            var responce = await userService.Register(request.Username, request.Email, request.Password);
            if (responce.Item1)
            {
                return Results.Ok(responce.Item2);
            }

            return Results.BadRequest(responce.Item2);
        }
    }
}
