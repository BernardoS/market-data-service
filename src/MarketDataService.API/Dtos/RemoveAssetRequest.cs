using MarketDataService.Application.Dtos;
using MarketDataService.Domain.Enum;

namespace MarketDataService.API.Dtos;

public class RemoveAssetRequest
{
    public string Symbol { get; set; }

    public RemoveAssetInput MapToInput()
    {
        return new RemoveAssetInput()
        {
            Symbol = this.Symbol,
        };
    }
}
