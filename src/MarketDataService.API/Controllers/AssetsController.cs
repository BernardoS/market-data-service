using MarketDataService.API.Dtos;
using MarketDataService.Application.Dtos;
using MarketDataService.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace MarketDataService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetsController : ControllerBase
{
    
    private IAssetService _assetService;

    public AssetsController(IAssetService assetService)
    {
        _assetService = assetService;
    }
    
    /// <summary>
    /// GET /assets/{symbol} -> Recupera o detalhes de um asset específico
    /// </summary>
    [HttpGet("{symbol}")]
    public IActionResult GetAssetBySymbol(string symbol)
    {

       var asset = _assetService.GetAssetBySymbol(symbol);
       
       if(asset == null)
           return NotFound();
       
       var result = new AssetResponseDto(asset!);

        return Ok(result);
    }

    /// <summary>
    /// GET /assets/ -> Recupera todos os assets habilitados
    /// </summary>
    [HttpGet]
    public IActionResult GetAllAssets()
    {
        // Mock data
        var assets = new List<AssetResponseDto>
        {
            new AssetResponseDto
            {
                Id = new Guid("123e4567-e89b-12d3-a456-426614174000"),
                Symbol = "AAPL",
                Name = "Apple Inc.",
                Description = "Empresa de tecnologia americana",
                AssetType = "Stock",
                Rating = 5,
                IsEnabled = true,
                CreatedAt = DateTime.UtcNow.AddDays(-30),
                UpdatedAt = DateTime.UtcNow.AddDays(-1)
            },
            new AssetResponseDto
            {
                Id = new Guid("223e4567-e89b-12d3-a456-426614174001"),
                Symbol = "GOOGL",
                Name = "Alphabet Inc.",
                Description = "Empresa de tecnologia e buscas",
                AssetType = "Stock",
                Rating = 4,
                IsEnabled = true,
                CreatedAt = DateTime.UtcNow.AddDays(-45),
                UpdatedAt = DateTime.UtcNow.AddDays(-2)
            },
            new AssetResponseDto
            {
                Id = new Guid("323e4567-e89b-12d3-a456-426614174002"),
                Symbol = "MSFT",
                Name = "Microsoft Corporation",
                Description = "Empresa de software e nuvem",
                AssetType = "Stock",
                Rating = 5,
                IsEnabled = true,
                CreatedAt = DateTime.UtcNow.AddDays(-60),
                UpdatedAt = DateTime.UtcNow.AddDays(-3)
            }
        };

        return Ok(assets);
    }

    /// <summary>
    /// POST /assets/ -> Recebe uma DTO e Serve para criar um asset
    /// </summary>
    [HttpPost]
    public IActionResult CreateAsset([FromBody] CreateAssetRequest createAssetRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Mock mapping
        var input = createAssetRequest.MapToInput();

        var createdAsset = _assetService.CreateAsset(input);

        return CreatedAtAction(nameof(GetAssetBySymbol), new { symbol = createdAsset.Symbol }, createdAsset);
    }

    /// <summary>
    /// PATCH /assets/rating/{symbol} -> Recebe uma DTO e serve para classificar o ativo e ativá-lo logo em seguida
    /// </summary>
    [HttpPatch("rating/")]
    public IActionResult UpdateAssetRating([FromBody] UpdateAssetRatingRequest updateAssetRatingRequest)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var input = updateAssetRatingRequest.MapToInput();

        var updatedAsset = _assetService.RateAsset(input);

        return Ok(updatedAsset);
    }

    /// <summary>
    /// DELETE /assets/{symbol} -> Delete um asset
    /// </summary>
    [HttpDelete("{symbol}")]
    public IActionResult DeleteAsset(string symbol)
    {
        // Mock delete response
        return NoContent();
    }
}
