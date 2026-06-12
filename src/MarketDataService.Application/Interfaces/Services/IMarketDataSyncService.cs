using MarketDataService.Domain.Enum;

namespace MarketDataService.Application.Interfaces.Services;

public interface IMarketDataSyncService
{
    bool SyncEnabledAsset(Guid assetId);
    
    bool SyncEnabledAssets();
}