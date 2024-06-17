
using Auction.Endpoints;
using Auction.Extensions;

namespace Auction
{
    public class Program
    {
        public static void Main()
        {
            var builder = WebApplication.CreateBuilder();
            var services = builder.Services;
            var configuration = builder.Configuration;

            services.AddServices();


            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();
            app.MapUsersEndpoints();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.Run();
        }
    }
}
