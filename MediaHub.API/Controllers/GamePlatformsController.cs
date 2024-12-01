using MediaHub.Core.Services.Abstract;
using MediaHub.Models.Dtos.GamePlatformDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GamePlatformsController : ControllerBase
{
    private readonly IGamePlatformsService _service;

    public GamePlatformsController(IGamePlatformsService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGamePlatformAsync([FromBody] CreateGamePlatformDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdPlatform = await _service.CreateGamePlatformAsync(dto);
        return CreatedAtAction(nameof(GetGamePlatformById), new { id = createdPlatform.GamePlatformId }, createdPlatform);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGamePlatformAsync(Guid id, [FromBody] UpdateGamePlatformDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != dto.GamePlatformId)
            return BadRequest("ID in URL and DTO must match.");

        await _service.UpdateGamePlatformAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGamePlatformAsync(Guid id)
    {
        await _service.DeleteGamePlatformAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGamePlatformById(Guid id)
    {
        var platform = await _service.GetGamePlatformByIdAsync(id);

        if (platform == null)
            return NotFound();

        return Ok(platform);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGamePlatformsAsync()
    {
        var platforms = await _service.GetAllGamePlatformsAsync();
        return Ok(platforms);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetGamePlatformByNameAsync(string name)
    {
        var platform = await _service.GetGamePlatformByNameAsync(name);
        if (platform == null)
            return NotFound();

        return Ok(platform);
    }
}
