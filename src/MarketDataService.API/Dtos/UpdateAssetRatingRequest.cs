using MarketDataService.Application.Dtos;

namespace MarketDataService.API.Dtos;

public class UpdateAssetRatingRequest
{
    public int Rating { get; set; }

    public UpdateAssetRatingInput MapToInput()
    {
        return new UpdateAssetRatingInput()
        {
            Rating = this.Rating
        };
    }
}
