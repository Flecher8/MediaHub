using MediaHub.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class RecommendationsController : ControllerBase
{
    private readonly IRecommendationsService _service;

    public RecommendationsController(IRecommendationsService service)
    {
        _service = service;
    }

    // For logged‐in users with a collection:
    [HttpGet("{collectionId:guid}")]
    public async Task<IActionResult> GetForUser(
        Guid collectionId,
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 100)
    {
        var list = await _service.GetRecommendationsAsync(collectionId, page, pageSize);
        return Ok(list);
    }

    // For guests:
    [HttpGet("guest")]
    public async Task<IActionResult> GetForGuest(
        [FromQuery] int page = 1,
        [FromQuery] int pageSize = 100)
    {
        var list = await _service.GetRecommendationsForGuestAsync(page, pageSize);
        return Ok(list);
    }

    // total pages for a user’s collection
    [HttpGet("{collectionId:guid}/pages")]
    public async Task<IActionResult> GetUserPageCount(
        Guid collectionId,
        [FromQuery] int pageSize = 100)
    {
        var totalPages = await _service.GetRecommendationsPageCountAsync(collectionId, pageSize);
        return Ok(new { PageSize = pageSize, TotalPages = totalPages });
    }

    // total pages for guests
    [HttpGet("guest/pages")]
    public async Task<IActionResult> GetGuestPageCount(
        [FromQuery] int pageSize = 100)
    {
        var totalPages = await _service.GetRecommendationsForGuestPageCountAsync(pageSize);
        return Ok(new { PageSize = pageSize, TotalPages = totalPages });
    }
}
