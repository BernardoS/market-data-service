using MarketDataService.Domain.Entities;

namespace MarketDataService.Application.Dtos;

public class AssetQuoteResponseDto
{
    public decimal Price { get; set; }
    public DateTime UpdatedAt { get; set; }

    public AssetQuoteResponseDto()
    {
    }

    public AssetQuoteResponseDto(AssetQuote quote)
    {
        Price = quote.Price;
        UpdatedAt = quote.UpdatedAt;
    }
}
