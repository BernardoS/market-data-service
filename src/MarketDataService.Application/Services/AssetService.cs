using MarketDataService.Application.Dtos;
using MarketDataService.Application.Interfaces.Repositories;
using MarketDataService.Application.Interfaces.Services;
using MarketDataService.Domain.Entities;

namespace MarketDataService.Application.Services;

public class AssetService : IAssetService
{
    private IAssetRepository _assetRepository;

    public AssetService(IAssetRepository assetRepository)
    {
        _assetRepository = assetRepository;
    }

    public ICollection<Asset> GetAssets(bool onlyEnabled = true)
    {
        return _assetRepository.GetAssets(onlyEnabled);
    }

    public Asset CreateAsset(CreateAssetInput input)
    {
        var newAsset = new Asset(input.Symbol, input.Name, input.Description, input.AssetType);

        _assetRepository.CreateAsset(newAsset);

        return newAsset;
    }

    public Asset RateAsset(UpdateAssetRatingInput input)
    {
        var asset = _assetRepository.GetAssetById(input.AssetId, false);

        if (asset == null)
        {
            throw new Exception("Asset not found");
        }

        asset.SetRating(input.Rating);

        _assetRepository.UpdateAsset(asset);

        return asset;
    }

    public Asset? GetAssetBySymbol(string symbol)
    {
        try
        {
            var asset = _assetRepository.GetAssetBySymbol(symbol);

            return asset;
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception("There was an error retrieving the asset");
        }
        
    }
}
