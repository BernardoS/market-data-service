namespace MarketDataService.Application.Dtos;

public class UpdateAssetRatingInput
{
    public Guid AssetId { get; set; }
    public int Rating { get; set; }
}
