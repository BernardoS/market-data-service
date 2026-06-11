using MarketDataService.Application.Dtos;
using MarketDataService.Domain.Entities;

namespace MarketDataService.Application.Interfaces.Services;

public interface IAssetService
{
     Asset CreateAsset(CreateAssetInput input);
     Asset RateAsset(UpdateAssetRatingInput input);   
     Asset? GetAssetBySymbol(string symbol);
}