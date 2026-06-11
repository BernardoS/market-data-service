using MarketDataService.Domain.Enum;

namespace MarketDataService.Domain.Entities;

public class Asset
{
    public Asset (string symbol, string name, string description, AssetType assetType)
    {
        Id = Guid.NewGuid();
        Symbol = symbol;
        Name = name;
        Description = description;
        AssetType = assetType;
        IsEnabled = false;
        CreatedAt = DateTime.UtcNow;
        UpdatedAt = DateTime.UtcNow;
    }

    public Asset()
    {
    }
    
    public Guid Id { get; private set; }
    public string Symbol { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    public AssetType AssetType { get; private set; }
    public int Rating { get; private set; }
    public bool IsEnabled {get; private set;} = false;
    public DateTime CreatedAt { get; private set; }
    public DateTime UpdatedAt { get; private set; }
    public ICollection<AssetQuote> Quotes { get; private set; } =  new List<AssetQuote>();

    public void SetRating(int rating)
    {
        if (rating > 10 || rating == 0)
        {
            throw new ArgumentOutOfRangeException(nameof(rating));
        }
        
        Rating = rating;
        IsEnabled = true;
        UpdatedAt = DateTime.UtcNow;
    }

    public void AddQuote(AssetQuote quote)
    {
        if (!IsEnabled)
        {
            throw new Exception("Asset are not enabled, set the asset rating before update asset quotes");
        }

        Quotes.Add(quote);
    }
    
}