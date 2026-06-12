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
        var assets = _assetService.GetAssets();
        
        var result = assets.Select(asset => new AssetResponseDto(asset));

        return Ok(result);
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
    /// DELETE /assets/ -> Delete um asset
    /// </summary>
    [HttpDelete]
    public IActionResult DeleteAsset(RemoveAssetRequest removeAssetRequest)
    {
        var input = removeAssetRequest.MapToInput();
        _assetService.RemoveAsset(input);
        return NoContent();
    }
}
