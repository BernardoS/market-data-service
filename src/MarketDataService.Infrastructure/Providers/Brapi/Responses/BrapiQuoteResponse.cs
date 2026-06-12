using System.Text.Json.Serialization;
using MarketDataService.Application.Dtos;

namespace MarketDataService.Infrastructure.Providers.Responses;

public class BrapiQuoteResponse
{
    [JsonPropertyName("results")]
    public List<BrapiAssetResponse> Results { get; set; } = [];

    [JsonPropertyName("requestedAt")]
    public DateTime RequestedAt { get; set; }

    [JsonPropertyName("took")]
    public int Took { get; set; }

    public IList<AssetDataOutput> MapToAssetDataOutputs()
    {
        var assetDataOutputs = new List<AssetDataOutput>();

        if (Results.Count == 0)
            return assetDataOutputs;

        assetDataOutputs = Results.Select(result => new AssetDataOutput()
        {
            Symbol = result.Symbol,
            Quote = result.RegularMarketPrice
        }).ToList();
        
        
        return assetDataOutputs;
    }
}