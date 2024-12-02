using MediaHub.Core.Services.Abstract;
using MediaHub.Models.Dtos.ContentStatusDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ContentStatusesController : ControllerBase
{
    private readonly IContentStatusesService _service;

    public ContentStatusesController(IContentStatusesService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateContentStatusAsync([FromBody] CreateContentStatusDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdStatus = await _service.CreateContentStatusAsync(dto);
        return CreatedAtAction(nameof(GetContentStatusById), new { id = createdStatus.ContentStatusId }, createdStatus);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateContentStatusAsync(Guid id, [FromBody] UpdateContentStatusDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != dto.ContentStatusId)
            return BadRequest("ID in URL and DTO must match.");

        await _service.UpdateContentStatusAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContentStatusAsync(Guid id)
    {
        await _service.DeleteContentStatusAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetContentStatusById(Guid id)
    {
        var status = await _service.GetContentStatusByIdAsync(id);

        if (status == null)
            return NotFound();

        return Ok(status);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllContentStatusesAsync()
    {
        var statuses = await _service.GetAllContentStatusesAsync();
        return Ok(statuses);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetContentStatusByNameAsync(string name)
    {
        var status = await _service.GetContentStatusByNameAsync(name);
        if (status == null)
            return NotFound();

        return Ok(status);
    }
}
