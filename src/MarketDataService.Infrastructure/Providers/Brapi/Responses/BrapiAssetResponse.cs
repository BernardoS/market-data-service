using System.Text.Json.Serialization;

namespace MarketDataService.Infrastructure.Providers.Responses;

public class BrapiAssetResponse
{
    [JsonPropertyName("symbol")]
    public string Symbol { get; set; } = string.Empty;

    [JsonPropertyName("shortName")]
    public string ShortName { get; set; } = string.Empty;

    [JsonPropertyName("longName")]
    public string LongName { get; set; } = string.Empty;

    [JsonPropertyName("currency")]
    public string Currency { get; set; } = string.Empty;

    [JsonPropertyName("regularMarketPrice")]
    public decimal RegularMarketPrice { get; set; }

    [JsonPropertyName("regularMarketDayHigh")]
    public decimal RegularMarketDayHigh { get; set; }

    [JsonPropertyName("regularMarketDayLow")]
    public decimal RegularMarketDayLow { get; set; }

    [JsonPropertyName("regularMarketDayRange")]
    public string RegularMarketDayRange { get; set; } = string.Empty;

    [JsonPropertyName("regularMarketChange")]
    public decimal RegularMarketChange { get; set; }

    [JsonPropertyName("regularMarketChangePercent")]
    public decimal RegularMarketChangePercent { get; set; }

    [JsonPropertyName("regularMarketTime")]
    public DateTime RegularMarketTime { get; set; }

    [JsonPropertyName("marketCap")]
    public long MarketCap { get; set; }

    [JsonPropertyName("regularMarketVolume")]
    public long RegularMarketVolume { get; set; }

    [JsonPropertyName("regularMarketPreviousClose")]
    public decimal RegularMarketPreviousClose { get; set; }

    [JsonPropertyName("regularMarketOpen")]
    public decimal RegularMarketOpen { get; set; }

    [JsonPropertyName("fiftyTwoWeekRange")]
    public string FiftyTwoWeekRange { get; set; } = string.Empty;

    [JsonPropertyName("fiftyTwoWeekLow")]
    public decimal FiftyTwoWeekLow { get; set; }

    [JsonPropertyName("fiftyTwoWeekHigh")]
    public decimal FiftyTwoWeekHigh { get; set; }

    [JsonPropertyName("priceEarnings")]
    public decimal? PriceEarnings { get; set; }

    [JsonPropertyName("earningsPerShare")]
    public decimal? EarningsPerShare { get; set; }

    [JsonPropertyName("logourl")]
    public string LogoUrl { get; set; } = string.Empty;
}