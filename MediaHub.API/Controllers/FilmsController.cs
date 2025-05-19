using MediaHub.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class FilmsController : ControllerBase
{
    private readonly IFilmService _filmService;

    public FilmsController(IFilmService filmService)
    {
        _filmService = filmService;
    }

    /// <summary>
    /// GET api/films/by-media/{mediaContentId}
    /// </summary>
    [HttpGet("by-media/{mediaContentId:guid}")]
    public async Task<IActionResult> GetByMediaContentId(Guid mediaContentId)
    {
        var dto = await _filmService.GetByMediaContentIdAsync(mediaContentId);
        if (dto == null) return NotFound();
        return Ok(dto);
    }
}
