using MarketDataService.Domain.Enum;

namespace MarketDataService.Domain.Entities;

public class Asset
{
    public Guid Id { get; private set; }
    public string Symbol { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public AssetType AssetType { get; private set; }
    public int Rating { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public ICollection<AssetQuote> Quotes { get; private set; }
}