using MarketDataService.Application.Dtos;
using Microsoft.AspNetCore.Mvc;

namespace MarketDataService.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class AssetsController : ControllerBase
{
    /// <summary>
    /// GET /assets/{symbol} -> Recupera o detalhes de um asset específico
    /// </summary>
    [HttpGet("{symbol}")]
    public IActionResult GetAssetBySymbol(string symbol)
    {
        // Mock data
        var asset = new AssetResponseDto
        {
            Id = new Guid("123e4567-e89b-12d3-a456-426614174000"),
            Symbol = symbol,
            Name = "Apple Inc.",
            Description = "Empresa de tecnologia americana",
            AssetType = "Stock",
            Rating = 5,
            IsEnabled = true,
            CreatedAt = DateTime.UtcNow.AddDays(-30),
            UpdatedAt = DateTime.UtcNow.AddDays(-1)
        };

        return Ok(asset);
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
    public IActionResult CreateAsset([FromBody] CreateAssetDto createAssetDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Mock mapping
        var input = createAssetDto.MapToInput();

        // Mock response
        var createdAsset = new AssetResponseDto
        {
            Id = Guid.NewGuid(),
            Symbol = createAssetDto.Symbol,
            Name = createAssetDto.Name,
            Description = createAssetDto.Description,
            AssetType = createAssetDto.AssetType.ToString(),
            Rating = 0,
            IsEnabled = false,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt = DateTime.UtcNow
        };

        return CreatedAtAction(nameof(GetAssetBySymbol), new { symbol = createdAsset.Symbol }, createdAsset);
    }

    /// <summary>
    /// PATCH /assets/rating/{symbol} -> Recebe uma DTO e serve para classificar o ativo e ativá-lo logo em seguida
    /// </summary>
    [HttpPatch("rating/{symbol}")]
    public IActionResult UpdateAssetRating(string symbol, [FromBody] UpdateAssetRatingDto updateAssetRatingDto)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Mock mapping
        var input = updateAssetRatingDto.MapToInput();

        // Mock response
        var updatedAsset = new AssetResponseDto
        {
            Id = new Guid("123e4567-e89b-12d3-a456-426614174000"),
            Symbol = symbol,
            Name = "Apple Inc.",
            Description = "Empresa de tecnologia americana",
            AssetType = "Stock",
            Rating = updateAssetRatingDto.Rating,
            IsEnabled = true, // Ativado após classificação
            CreatedAt = DateTime.UtcNow.AddDays(-30),
            UpdatedAt = DateTime.UtcNow
        };

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
