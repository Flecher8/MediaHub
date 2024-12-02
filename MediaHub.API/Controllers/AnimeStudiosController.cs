using MediaHub.Core.Services.Abstract;
using MediaHub.Models.Dtos.AnimeStudioDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnimeStudiosController : ControllerBase
{
    private readonly IAnimeStudiosService _service;

    public AnimeStudiosController(IAnimeStudiosService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateAnimeStudioAsync([FromBody] CreateAnimeStudioDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdStudio = await _service.CreateAnimeStudioAsync(dto);
        return CreatedAtAction(nameof(GetAnimeStudioById), new { id = createdStudio.AnimeStudioId }, createdStudio);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAnimeStudioAsync(Guid id, [FromBody] UpdateAnimeStudioDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != dto.AnimeStudioId)
            return BadRequest("ID in URL and DTO must match.");

        await _service.UpdateAnimeStudioAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAnimeStudioAsync(Guid id)
    {
        await _service.DeleteAnimeStudioAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetAnimeStudioById(Guid id)
    {
        var studio = await _service.GetAnimeStudioByIdAsync(id);

        if (studio == null)
            return NotFound();

        return Ok(studio);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllAnimeStudiosAsync()
    {
        var studios = await _service.GetAllAnimeStudiosAsync();
        return Ok(studios);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetAnimeStudioByNameAsync(string name)
    {
        var studio = await _service.GetAnimeStudioByNameAsync(name);
        if (studio == null)
            return NotFound();

        return Ok(studio);
    }
}
