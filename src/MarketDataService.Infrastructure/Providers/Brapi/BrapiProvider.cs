using System.Net.Http.Json;
using System.Text.Json;
using MarketDataService.Application.Dtos;
using MarketDataService.Application.Interfaces.Providers;
using MarketDataService.Domain.Entities;
using MarketDataService.Infrastructure.Providers.Responses;

namespace MarketDataService.Infrastructure.Providers;

public class BrapiProvider: IMarketDataProvider
{
    private readonly HttpClient _httpClient;
    public BrapiProvider(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    
    public async Task<ICollection<AssetDataOutput>> GetAssetsData(ICollection<string> symbols)
    {
        var assetDataList = new List<AssetDataOutput>();
        
        foreach (var symbol in symbols)
        {
            var assetData = await GetAssetData(symbol);
            
            assetDataList.Add(assetData);
        }

        return assetDataList;
    }

    public async Task<AssetDataOutput> GetAssetData(string symbol)
    {
        var response = await _httpClient.GetAsync($"quote/{symbol}");
        
        response.EnsureSuccessStatusCode();

        return MapResponseToAsset(response);
    }

    private AssetDataOutput MapResponseToAsset(HttpResponseMessage response)
    {
        var content = response.Content.ReadAsStringAsync().Result;
        
        var brapiResponse = JsonSerializer.Deserialize<BrapiQuoteResponse>(content,
            new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

        var assetData = brapiResponse.MapToAssetDataOutputs().FirstOrDefault();
        
        return assetData;
    }
    
}