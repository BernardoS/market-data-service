namespace MarketDataService.Domain.Entities;

public class AssetQuote
{
    public AssetQuote(Guid assetId, decimal price)
    {
        this.Id = Guid.NewGuid();
        this.AssetId = assetId;
        this.Price = price;
        this.CreatedAt = DateTime.UtcNow;
        this.UpdatedAt = DateTime.UtcNow;
    }

    public AssetQuote(){}
    
    public Guid Id { get; private set; }
    public Guid AssetId { get; private set; }
    public decimal Price { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public Asset Asset { get; private set; }

}