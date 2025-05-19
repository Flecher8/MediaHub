using MediaHub.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MangaController : ControllerBase
{
    private readonly IMangaService _mangaService;

    public MangaController(IMangaService mangaService)
    {
        _mangaService = mangaService;
    }

    [HttpGet("by-media/{mediaContentId:guid}")]
    public async Task<IActionResult> GetByMediaContentId(Guid mediaContentId)
    {
        var dto = await _mangaService.GetByMediaContentIdAsync(mediaContentId);
        if (dto == null) return NotFound();
        return Ok(dto);
    }
}
