using MarketDataService.Application.Dtos;
using MarketDataService.Domain.Enum;

namespace MarketDataService.API.Dtos;

public class CreateAssetRequest
{
    public string Symbol { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public AssetType AssetType { get; set; }

    public CreateAssetInput MapToInput()
    {
        return new CreateAssetInput()
        {
            Symbol = this.Symbol,
            Name = this.Name,
            Description = this.Description,
            AssetType = this.AssetType
        };
    }
}
