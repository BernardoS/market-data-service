using MarketDataService.Application.Dtos;
using MarketDataService.Domain.Entities;

namespace MarketDataService.Application.Interfaces.Providers;

public interface IMarketDataProvider
{
    Task<ICollection<AssetDataOutput>> GetAssetsData(ICollection<string> symbols);
   Task<AssetDataOutput> GetAssetData(string symbol);
}