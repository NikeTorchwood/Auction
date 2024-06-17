using Microsoft.EntityFrameworkCore;
using UsersService.Domain;

namespace UsersService.Infrastructure.EntityFramework;

public class UserDbContext(DbContextOptions<UserDbContext> options) : DbContext(options)
{
    public DbSet<User?> Users { get; set; }
}