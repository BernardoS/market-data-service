using MarketDataService.Domain.Entities;

namespace MarketDataService.Application.Interfaces.Providers;

public interface IMarketDataProvider
{
    ICollection<Asset> GetAssets(ICollection<string> symbols);
    Asset GetAsset(string symbol);
}