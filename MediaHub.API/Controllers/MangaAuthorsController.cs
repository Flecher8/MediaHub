using MediaHub.Core.Services.Abstract;
using MediaHub.Models.Dtos.MangaAuthorDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MangaAuthorsController : ControllerBase
{
    private readonly IMangaAuthorsService _service;

    public MangaAuthorsController(IMangaAuthorsService service)
    {
        _service = service;
    }

    [HttpPost]
    public async Task<IActionResult> CreateMangaAuthorAsync([FromBody] CreateMangaAuthorDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var createdAuthor = await _service.CreateMangaAuthorAsync(dto);
        return CreatedAtAction(nameof(GetMangaAuthorById), new { id = createdAuthor.MangaAuthorId }, createdAuthor);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateMangaAuthorAsync(Guid id, [FromBody] UpdateMangaAuthorDto dto)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        if (id != dto.MangaAuthorId)
            return BadRequest("ID in URL and DTO must match.");

        await _service.UpdateMangaAuthorAsync(dto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMangaAuthorAsync(Guid id)
    {
        await _service.DeleteMangaAuthorAsync(id);
        return NoContent();
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMangaAuthorById(Guid id)
    {
        var author = await _service.GetMangaAuthorByIdAsync(id);

        if (author == null)
            return NotFound();

        return Ok(author);
    }

    [HttpGet]
    public async Task<IActionResult> GetAllMangaAuthorsAsync()
    {
        var authors = await _service.GetAllMangaAuthorsAsync();
        return Ok(authors);
    }

    [HttpGet("by-name/{name}")]
    public async Task<IActionResult> GetMangaAuthorByNameAsync(string name)
    {
        var author = await _service.GetMangaAuthorByNameAsync(name);
        if (author == null)
            return NotFound();

        return Ok(author);
    }
}
