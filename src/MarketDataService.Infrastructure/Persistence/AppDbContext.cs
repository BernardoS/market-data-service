using MarketDataService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MarketDataService.Infrastructure.Persistence;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Asset> Assets { get; set; }
    public DbSet<AssetQuote> AssetQuotes { get; set; }
}