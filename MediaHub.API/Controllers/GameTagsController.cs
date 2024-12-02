using MediaHub.Core.Services.Abstract;
using MediaHub.Models.Dtos.GameTagDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GameTagsController : ControllerBase
{
    private readonly IGameTagsService _service;

    public GameTagsController(IGameTagsService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGameTagAsync([FromBody] CreateGameTagDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdTag = await _service.CreateGameTagAsync(dto);
        return CreatedAtAction(nameof(GetGameTagById), new { id = createdTag.GameTagId }, createdTag);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGameTagAsync(Guid id, [FromBody] UpdateGameTagDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != dto.GameTagId)
            return BadRequest("ID in URL and DTO must match.");

        await _service.UpdateGameTagAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGameTagAsync(Guid id)
    {
        await _service.DeleteGameTagAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGameTagById(Guid id)
    {
        var tag = await _service.GetGameTagByIdAsync(id);

        if (tag == null)
            return NotFound();

        return Ok(tag);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGameTagsAsync()
    {
        var tags = await _service.GetAllGameTagsAsync();
        return Ok(tags);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetGameTagByNameAsync(string name)
    {
        var tag = await _service.GetGameTagByNameAsync(name);
        if (tag == null)
            return NotFound();

        return Ok(tag);
    }
}
