using MediaHub.Core.Services.Abstract;
using MediaHub.Models.Dtos.MediaInteractionStatusDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MediaInteractionStatusesController : ControllerBase
{
    private readonly IMediaInteractionStatusService _service;

    public MediaInteractionStatusesController(IMediaInteractionStatusService service)
    {
        _service = service;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var dto = await _service.GetByIdAsync(id);
        if (dto == null) return NotFound();
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateMediaInteractionStatusDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        var created = await _service.AddAsync(dto);
        return CreatedAtAction(nameof(GetById),
            new { id = created.MediaInteractionStatusId }, created);
    }

    [HttpPut("{id:guid}")]
    public async Task<IActionResult> Update(Guid id, [FromBody] UpdateMediaInteractionStatusDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (id != dto.MediaInteractionStatusId) return BadRequest("ID mismatch");
        var updated = await _service.UpdateAsync(dto);
        return Ok(updated);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _service.DeleteAsync(id);
        return NoContent();
    }

    [HttpGet("collection/{collectionId:guid}/media")]
    public async Task<IActionResult> GetMediaByCollection(Guid collectionId)
    {
        var media = await _service.GetMediaByCollectionAsync(collectionId);
        return Ok(media);
    }

    [HttpDelete("collection/{collectionId:guid}/media/{mediaContentId:guid}")]
    public async Task<IActionResult> DeleteByCollectionAndMedia(Guid collectionId, Guid mediaContentId)
    {
        await _service.DeleteByCollectionAndMediaAsync(collectionId, mediaContentId);
        return NoContent();
    }

    [HttpGet("collection/{collectionId:guid}/media/{mediaContentId:guid}")]
    public async Task<IActionResult> GetByCollectionAndMedia(Guid collectionId, Guid mediaContentId)
    {
        var dto = await _service.GetByCollectionAndMediaAsync(collectionId, mediaContentId);
        if (dto == null) return NotFound();
        return Ok(dto);
    }
}
