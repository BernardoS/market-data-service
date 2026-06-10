using MarketDataService.Domain.Enum;

namespace MarketDataService.Application.Interfaces.Services;

public interface IMarketDataSyncService
{
    bool SyncActiveAsset(Guid assetId);
    
    bool SyncActiveAssets();
}