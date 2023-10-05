using Microsoft.EntityFrameworkCore;

namespace FitnessApp.Models.Context;

public class FitnessContext : DbContext
{
    public DbSet<Product> Products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);

        optionsBuilder.UseSqlServer(connectionString: "Server=localhost;Database=FitnessDb; TrustServerCertificate=True; Trusted_Connection=True;");
    }
}
