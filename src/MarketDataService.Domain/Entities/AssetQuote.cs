namespace MarketDataService.Domain.Entities;

public class AssetQuote
{
    public Guid Id { get; private set; }
    public Guid AssetId { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Asset Asset { get; private set; }
}