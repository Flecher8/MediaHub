using MediaHub.Core.Services.Abstract;
using MediaHub.Models.Dtos.MediaContentDtos;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class MediaContentsController : ControllerBase
{
    private readonly IMediaContentsService _service;

    public MediaContentsController(IMediaContentsService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMediaContentAsync([FromBody] CreateMediaContentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdMediaContent = await _service.CreateMediaContentAsync(dto);
        return CreatedAtAction(nameof(GetMediaContentById), new { id = createdMediaContent.MediaContentId },
            createdMediaContent);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMediaContentAsync(Guid id, [FromBody] UpdateMediaContentDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != dto.UpdateMediaContentId)
            return BadRequest("ID in URL and DTO must match.");

        await _service.UpdateMediaContentAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMediaContentAsync(Guid id)
    {
        await _service.DeleteMediaContentAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMediaContentById(Guid id)
    {
        var mediaContent = await _service.GetMediaContentByIdAsync(id);

        if (mediaContent == null)
            return NotFound();

        return Ok(mediaContent);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMediaContentsAsync()
    {
        var mediaContent = await _service.GetAllMediaContentsAsync();
        return Ok(mediaContent);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetMediaContentByNameAsync(string name)
    {
        var mediaContent = await _service.GetMediaContentByTitleAsync(name);
        if (mediaContent == null)
            return NotFound();

        return Ok(mediaContent);
    }
}
