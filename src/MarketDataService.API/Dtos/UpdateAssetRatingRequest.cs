namespace MarketDataService.API.Dtos;

public class UpdateAssetRatingRequest
{
    public int Rating { get; set; }

    public object MapToInput()
    {
        return new
        {
            Rating = this.Rating
        };
    }
}
