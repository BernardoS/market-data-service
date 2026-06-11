using MarketDataService.Application.Dtos;
using MarketDataService.Domain.Entities;

namespace MarketDataService.Application.Interfaces.Services;

public interface IAssetService
{
     ICollection<Asset> GetAssets(bool onlyEnabled = true);
     Asset CreateAsset(CreateAssetInput input);
     Asset RateAsset(UpdateAssetRatingInput input);   
     Asset? GetAssetBySymbol(string symbol);
     Asset RemoveAsset(RemoveAssetInput input);
}