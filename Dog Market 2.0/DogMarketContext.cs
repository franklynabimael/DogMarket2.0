using Dog_Market_2._0.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Dog_Market_2._0;

public class DogMarketContext : IdentityDbContext<User>
{
    public const string DefaultSchema = "DogMarketDB";
    public DogMarketContext(DbContextOptions<DogMarketContext> options) : base(options)
    {
        Produts = Set<Product>();
    }

    public DbSet<Product> Produts { get; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(DogMarketContext).Assembly);
        modelBuilder.HasDefaultSchema(DefaultSchema);
        modelBuilder.Entity<User>();
        base.OnModelCreating(modelBuilder);
    }
}

