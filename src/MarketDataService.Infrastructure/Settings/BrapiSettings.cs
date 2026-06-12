namespace MarketDataService.Infrastructure.Settings;

public class BrapiSettings
{
    public const string SectionName = "Brapi";

    public string BaseUrl { get; set; } = string.Empty;
    public string ApiKey { get; set; } = string.Empty;
}