
using Microsoft.EntityFrameworkCore;
using UsersService.Infrastructure.EntityFramework;
using UsersService.Infrastructure.RepositoriesImplementations;
using UsersService.Services.RepositoriesAbstractions;
using UsersService.Services.ServicesAbstractions;
using UsersService.Services.ServicesImplementations;

namespace UsersService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var services = builder.Services;
            var configuration = builder.Configuration;
            var connectionString = configuration.GetConnectionString("UserDb");
            // Add services to the container.
            services.AddDbContext<UserDbContext>(opt=>opt.UseNpgsql(connectionString));
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();



            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
