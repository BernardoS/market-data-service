using MarketDataService.Application.Interfaces.Providers;
using MarketDataService.Application.Interfaces.Repositories;
using MarketDataService.Application.Interfaces.Services;

namespace MarketDataService.Application.Services;

public class MarketDataSyncService : IMarketDataSyncService
{
    private IMarketDataProvider _marketDataProvider;

    private IAssetRepository _assetRepository;
    
    public MarketDataSyncService(IMarketDataProvider marketDataProvider, IAssetRepository assetRepository)
    {
        _marketDataProvider = marketDataProvider;
        _assetRepository = assetRepository;
    }
    
    public bool SyncEnabledAsset(Guid assetId)
    {
        throw new NotImplementedException();
    }

    public bool SyncEnabledAssets()
    {
        var enabledAssets = _assetRepository.GetAssets();

        var tickerList = enabledAssets.Select(asset => asset.Symbol).ToList();

        var assetData =  _marketDataProvider.GetAssetsData(tickerList).Result;

        foreach (var enabledAsset in enabledAssets)
        {
            var enabledAssetData = assetData.FirstOrDefault(asset => asset.Symbol == enabledAsset.Symbol);
            
            _assetRepository.AddQuote(enabledAsset.Id, enabledAssetData.Quote);
        }
        
        return assetData.Any();
    }
}