using MarketDataService.Application.Dtos;

namespace MarketDataService.API.Dtos;

public class UpdateAssetRatingRequest
{
    public Guid AssetId { get; set; }
    public int Rating { get; set; }

    public UpdateAssetRatingInput MapToInput()
    {
        return new UpdateAssetRatingInput()
        {
            AssetId = this.AssetId,
            Rating = this.Rating
        };
    }
}
