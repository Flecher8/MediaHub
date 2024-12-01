using MediaHub.Core.Services.Abstract;
using MediaHub.Models.Dtos.GameDeveloperDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GameDevelopersController : ControllerBase
{
    private readonly IGameDevelopersService _service;

    public GameDevelopersController(IGameDevelopersService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGameDeveloperAsync([FromBody] CreateGameDeveloperDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdDeveloper = await _service.CreateGameDeveloperAsync(dto);
        return CreatedAtAction(nameof(GetGameDeveloperById), new { id = createdDeveloper.GameDeveloperId }, createdDeveloper);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGameDeveloperAsync(Guid id, [FromBody] UpdateGameDeveloperDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != dto.GameDeveloperId)
            return BadRequest("ID in URL and DTO must match.");

        await _service.UpdateGameDeveloperAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGameDeveloperAsync(Guid id)
    {
        await _service.DeleteGameDeveloperAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGameDeveloperById(Guid id)
    {
        var developer = await _service.GetGameDeveloperByIdAsync(id);

        if (developer == null)
            return NotFound();

        return Ok(developer);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGameDevelopersAsync()
    {
        var developers = await _service.GetAllGameDevelopersAsync();
        return Ok(developers);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetGameDeveloperByNameAsync(string name)
    {
        var developer = await _service.GetGameDeveloperByNameAsync(name);
        if (developer == null)
            return NotFound();

        return Ok(developer);
    }
}
