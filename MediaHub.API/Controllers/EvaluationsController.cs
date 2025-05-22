using MediaHub.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class EvaluationsController : ControllerBase
{
    private readonly IEvaluationService _service;

    public EvaluationsController(IEvaluationService service)
        => _service = service;

    /// <summary>
    /// GET /api/Evaluations
    /// </summary>
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var list = await _service.GetAllAsync();
        return Ok(list);
    }
}
