using MediaHub.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnimeController : ControllerBase
{
    private readonly IAnimeService _animeService;

    public AnimeController(IAnimeService animeService)
    {
        _animeService = animeService;
    }

    [HttpGet("by-media/{mediaContentId:guid}")]
    public async Task<IActionResult> GetByMediaContentId(Guid mediaContentId)
    {
        var dto = await _animeService.GetByMediaContentIdAsync(mediaContentId);
        if (dto == null) return NotFound();
        return Ok(dto);
    }
}
