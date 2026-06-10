using MarketDataService.Application.Interfaces.Providers;
using MarketDataService.Application.Interfaces.Services;

namespace MarketDataService.Application.Services;

public class MarketDataSyncService : IMarketDataSyncService
{
    private IMarketDataProvider _marketDataProvider;

    public MarketDataSyncService(IMarketDataProvider marketDataProvider)
    {
        _marketDataProvider = marketDataProvider;
    }
    
    public bool SyncActiveAsset(Guid assetId)
    {
        throw new NotImplementedException();
    }

    public bool SyncActiveAssets()
    {
        throw new NotImplementedException();
    }
}