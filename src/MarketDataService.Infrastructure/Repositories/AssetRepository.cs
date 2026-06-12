using MarketDataService.Application.Interfaces.Repositories;
using MarketDataService.Domain.Entities;
using MarketDataService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
            return _dbContext.Assets
                .Include(asset => asset.Quotes)
                .FirstOrDefault(a => a.Id == assetId &&  a.IsEnabled);
        }
        
        return _dbContext.Assets
            .Include(asset => asset.Quotes)
            .FirstOrDefault(a => a.Id == assetId);
    }
    
    public Asset? GetAssetBySymbol(string symbol, bool onlyEnabled = true)
    {
        if (onlyEnabled)
        {
            return _dbContext.Assets
                .Include(asset => asset.Quotes)
                .FirstOrDefault(a => a.Symbol == symbol &&  a.IsEnabled);
        }
        
        return _dbContext.Assets
            .Include(asset => asset.Quotes)
            .FirstOrDefault(a => a.Symbol == symbol);
    }

    public ICollection<Asset> GetAssets(bool onlyEnabled = true)
    {
        var assets = new List<Asset>();

        if (onlyEnabled)
        {
            assets = _dbContext.Assets.Where(a => a.IsEnabled)
                .Include(asset => asset.Quotes)
                .AsNoTracking()
                .ToList();
            
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

    public void AddQuote(Guid assetId, decimal price)
    {
        var newQuote = new AssetQuote(assetId, price);
        
        _dbContext.AssetQuotes.Add(newQuote);
        _dbContext.SaveChanges();
    }

    public Asset RemoveAsset(Asset asset)
    {
        _dbContext.Assets.Remove(asset);
        _dbContext.SaveChanges();
        return asset;
    }
}