using MarketDataService.Domain.Entities;
using MarketDataService.Domain.Enum;

namespace MarketDataService.Application.Dtos;

public class AssetResponseDto
{
    public Guid Id { get; set; }
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public string AssetType { get; set; }
    public int Rating { get; set; }
    public bool IsEnabled { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    
    public AssetResponseDto()
    {
    }

    public AssetResponseDto(Asset asset)
    {
        Id = asset.Id;
        Symbol = asset.Symbol;
        Name = asset.Name;
        Description = asset.Description;
        AssetType = asset.AssetType.ToString();
        Rating = asset.Rating;
        IsEnabled = asset.IsEnabled;
        CreatedAt = asset.CreatedAt;
        UpdatedAt = asset.UpdatedAt;
    }
}
