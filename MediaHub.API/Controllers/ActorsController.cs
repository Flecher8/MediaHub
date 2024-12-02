using MediaHub.Core.Services.Abstract;
using MediaHub.Models.Dtos.ActorDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ActorsController : ControllerBase
{
    private readonly IActorsService _service;

    public ActorsController(IActorsService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateActorAsync([FromBody] CreateActorDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdActor = await _service.CreateActorAsync(dto);
        return CreatedAtAction(nameof(GetActorById), new { id = createdActor.ActorId }, createdActor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateActorAsync(Guid id, [FromBody] UpdateActorDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != dto.ActorId)
            return BadRequest("ID in URL and DTO must match.");

        await _service.UpdateActorAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteActorAsync(Guid id)
    {
        await _service.DeleteActorAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetActorById(Guid id)
    {
        var actor = await _service.GetActorByIdAsync(id);

        if (actor == null)
            return NotFound();

        return Ok(actor);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllActorsAsync()
    {
        var actors = await _service.GetAllActorsAsync();
        return Ok(actors);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetActorByNameAsync(string name)
    {
        var actor = await _service.GetActorByNameAsync(name);
        if (actor == null)
            return NotFound();

        return Ok(actor);
    }
}
