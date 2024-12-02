using MediaHub.Core.Services.Abstract;
using MediaHub.Models.Dtos.DirectorDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class DirectorsController : ControllerBase
{
    private readonly IDirectorsService _service;

    public DirectorsController(IDirectorsService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateDirectorAsync([FromBody] CreateDirectorDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdDirector = await _service.CreateDirectorAsync(dto);
        return CreatedAtAction(nameof(GetDirectorById), new { id = createdDirector.DirectorId }, createdDirector);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateDirectorAsync(Guid id, [FromBody] UpdateDirectorDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != dto.DirectorId)
            return BadRequest("ID in URL and DTO must match.");

        await _service.UpdateDirectorAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteDirectorAsync(Guid id)
    {
        await _service.DeleteDirectorAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetDirectorById(Guid id)
    {
        var director = await _service.GetDirectorByIdAsync(id);

        if (director == null)
            return NotFound();

        return Ok(director);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllDirectorsAsync()
    {
        var directors = await _service.GetAllDirectorsAsync();
        return Ok(directors);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetDirectorByNameAsync(string name)
    {
        var director = await _service.GetDirectorByNameAsync(name);
        if (director == null)
            return NotFound();

        return Ok(director);
    }
}
