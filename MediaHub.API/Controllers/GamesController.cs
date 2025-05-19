using MediaHub.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GamesController : ControllerBase
{
    private readonly IGameService _gameService;

    public GamesController(IGameService gameService)
    {
        _gameService = gameService;
    }

    // GET api/games/by-media/{mediaContentId}
    [HttpGet("by-media/{mediaContentId:guid}")]
    public async Task<IActionResult> GetByMediaContentId(Guid mediaContentId)
    {
        var dto = await _gameService.GetByMediaContentIdAsync(mediaContentId);
        if (dto == null) return NotFound();
        return Ok(dto);
    }
}
