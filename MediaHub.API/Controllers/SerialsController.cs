using MediaHub.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SerialsController : ControllerBase
{
    private readonly ISerialService _serialService;

    public SerialsController(ISerialService serialService)
    {
        _serialService = serialService;
    }

    // GET api/serials/by-media/{mediaContentId}
    [HttpGet("by-media/{mediaContentId:guid}")]
    public async Task<IActionResult> GetByMediaContentId(Guid mediaContentId)
    {
        var dto = await _serialService.GetByMediaContentIdAsync(mediaContentId);
        if (dto == null) return NotFound();
        return Ok(dto);
    }
}
