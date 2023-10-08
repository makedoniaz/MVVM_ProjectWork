using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Models.Context;

public class FitnessContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    public DbSet<User> Users { get; set; }

    public DbSet<UserInfo> UsersInfo { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(connectionString: "Server=localhost;Database=FitnessDb; TrustServerCertificate=True; User Id=admin;Password=admin");
    }
}
