using MediaHub.Core.Services.Abstract;
using MediaHub.Models.Dtos.RecommendationCollectionDtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecommendationCollectionsController : ControllerBase
{
    private readonly IRecommendationCollectionsService _service;

    public RecommendationCollectionsController(IRecommendationCollectionsService service)
    {
        _service = service;
    }

    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetById(Guid id)
    {
        var dto = await _service.GetCollectionByIdAsync(id);
        return Ok(dto);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateRecommendationCollectionDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var created = await _service.CreateCollectionAsync(dto);
        return CreatedAtAction(null, new { id = created.CollectionId }, created);
    }

    [HttpDelete("{id:guid}")]
    public async Task<IActionResult> DeleteCollection(Guid id)
    {
        await _service.DeleteCollectionAsync(id);
        return NoContent();
    }

    [HttpPost("{collectionId:guid}/users")]
    public async Task<IActionResult> AddUser(Guid collectionId, [FromBody] AddUserToCollectionDto dto)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);
        if (dto.CollectionId != collectionId) return BadRequest("CollectionId mismatch");

        await _service.AddUserToCollectionAsync(dto);
        return NoContent();
    }

    [HttpDelete("{collectionId:guid}/users/{userId:guid}")]
    public async Task<IActionResult> RemoveUser(Guid collectionId, Guid userId)
    {
        await _service.RemoveUserFromCollectionAsync(collectionId, userId);
        return NoContent();
    }

    [HttpGet("user/{userId:guid}")]
    public async Task<IActionResult> GetByUser(Guid userId)
    {
        var list = await _service.GetUserCollectionsAsync(userId);
        return Ok(list);
    }
}
