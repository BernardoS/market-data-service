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

}
