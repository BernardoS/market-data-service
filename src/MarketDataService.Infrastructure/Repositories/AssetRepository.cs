using MarketDataService.Application.Interfaces.Repositories;
using MarketDataService.Domain.Entities;
using MarketDataService.Infrastructure.Persistence;

namespace MarketDataService.Infrastructure.Repositories;

public class AssetRepository: IAssetRepository
{
    private AppDbContext _dbContext;

    public AssetRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }
    
    public Asset? GetAssetById(Guid assetId, bool onlyEnabled = true)
    {
        if (onlyEnabled)
        {
            return _dbContext.Assets.FirstOrDefault(a => a.Id == assetId &&  a.IsEnabled);
        }
        
        return _dbContext.Assets.FirstOrDefault(a => a.Id == assetId);
    }
    
    public Asset? GetAssetBySymbol(string symbol, bool onlyEnabled = true)
    {
        if (onlyEnabled)
        {
            return _dbContext.Assets.FirstOrDefault(a => a.Symbol == symbol &&  a.IsEnabled);
        }
        
        return _dbContext.Assets.FirstOrDefault(a => a.Symbol == symbol);
    }

    public ICollection<Asset> GetAssets(bool onlyEnabled = true)
    {
        var assets = new List<Asset>();

        if (onlyEnabled)
        {
            assets = _dbContext.Assets.Where(a => a.IsEnabled).ToList();
            
            return assets;
        }
        
        assets = _dbContext.Assets.ToList();

        return assets;
    }

    public Asset CreateAsset(Asset asset)
    {
        _dbContext.Assets.Add(asset);
        _dbContext.SaveChanges();

        return asset;
    }

    public Asset UpdateAsset(Asset asset)
    {
        _dbContext.Assets.Update(asset);
        _dbContext.SaveChanges();
        
        return asset;
    }

    public Asset AddQuote(Guid assetId, AssetQuote asset)
    {
        throw new NotImplementedException();
    }
}