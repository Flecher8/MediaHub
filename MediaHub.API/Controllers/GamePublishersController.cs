using MediaHub.Core.Services.Abstract;
using MediaHub.Models.Dtos.GamePublisherDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GamePublishersController : ControllerBase
{
    private readonly IGamePublishersService _service;

    public GamePublishersController(IGamePublishersService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateGamePublisherAsync([FromBody] CreateGamePublisherDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdPublisher = await _service.CreateGamePublisherAsync(dto);
        return CreatedAtAction(nameof(GetGamePublisherById), new { id = createdPublisher.GamePublisherId }, createdPublisher);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateGamePublisherAsync(Guid id, [FromBody] UpdateGamePublisherDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != dto.GamePublisherId)
            return BadRequest("ID in URL and DTO must match.");

        await _service.UpdateGamePublisherAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteGamePublisherAsync(Guid id)
    {
        await _service.DeleteGamePublisherAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetGamePublisherById(Guid id)
    {
        var publisher = await _service.GetGamePublisherByIdAsync(id);

        if (publisher == null)
            return NotFound();

        return Ok(publisher);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllGamePublishersAsync()
    {
        var publishers = await _service.GetAllGamePublishersAsync();
        return Ok(publishers);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetGamePublisherByNameAsync(string name)
    {
        var publisher = await _service.GetGamePublisherByNameAsync(name);
        if (publisher == null)
            return NotFound();

        return Ok(publisher);
    }
}
