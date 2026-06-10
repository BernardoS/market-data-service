using MarketDataService.Application.Interfaces.Providers;
using MarketDataService.Domain.Entities;

namespace MarketDataService.Infrastructure.Providers;

public class BrapiProvider: IMarketDataProvider
{
    public ICollection<Asset> GetAssets(ICollection<string> symbols)
    {
        throw new NotImplementedException();
    }

    public Asset GetAsset(string symbol)
    {
        throw new NotImplementedException();
    }
}