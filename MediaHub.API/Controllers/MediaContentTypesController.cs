using MediaHub.Core.Services.Abstract;
using MediaHub.Models.Dtos.MediaContentTypeDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MediaContentTypesController : ControllerBase
{
    private readonly IMediaContentTypesService _service;

    public MediaContentTypesController(IMediaContentTypesService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMediaContentTypeAsync([FromBody] CreateMediaContentTypeDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdType = await _service.CreateMediaContentTypeAsync(dto);
        return CreatedAtAction(nameof(GetMediaContentTypeById), new { id = createdType.TypeId }, createdType);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMediaContentTypeAsync(Guid id, [FromBody] UpdateMediaContentTypeDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != dto.TypeId)
            return BadRequest("ID in URL and DTO must match.");

        await _service.UpdateMediaContentTypeAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMediaContentTypeAsync(Guid id)
    {
        await _service.DeleteMediaContentTypeAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMediaContentTypeById(Guid id)
    {
        var mediaContentType = await _service.GetMediaContentTypeByIdAsync(id);

        if (mediaContentType == null)
            return NotFound();

        return Ok(mediaContentType);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMediaContentTypesAsync()
    {
        var mediaContentTypes = await _service.GetAllMediaContentTypesAsync();
        return Ok(mediaContentTypes);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetMediaContentTypeByNameAsync(string name)
    {
        var mediaContentType = await _service.GetMediaContentTypeByNameAsync(name);
        if (mediaContentType == null)
            return NotFound();

        return Ok(mediaContentType);
    }
}
