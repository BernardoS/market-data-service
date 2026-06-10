using MarketDataService.Domain.Enum;

namespace MarketDataService.API.Dtos;

public class CreateAssetRequest
{
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public AssetType AssetType { get; set; }

    public object MapToInput()
    {
        return new
        {
            Symbol = this.Symbol,
            Name = this.Name,
            Description = this.Description,
            AssetType = this.AssetType.ToString()
        };
    }
}
