using MarketDataService.Domain.Enum;

namespace MarketDataService.Application.Dtos;

public class CreateAssetInput
{
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public AssetType AssetType { get; set; }
}
