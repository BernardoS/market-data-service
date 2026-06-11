using MarketDataService.Domain.Entities;

namespace MarketDataService.Application.Interfaces.Repositories;

public interface IAssetRepository
{
    Asset? GetAssetById(Guid assetId, bool onlyEnabled = true);
    Asset? GetAssetBySymbol(string symbol, bool onlyEnabled = true);
    ICollection<Asset> GetAssets(bool onlyEnabled = true);
    Asset CreateAsset(Asset asset);
    Asset UpdateAsset(Asset asset);
    Asset AddQuote(Guid assetId , AssetQuote asset);
}