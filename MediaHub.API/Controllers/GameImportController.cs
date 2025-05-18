using MediaHub.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class GameImportController : ControllerBase
{
    private readonly IGameImportService _import;
    private readonly IWebHostEnvironment _env;

    public GameImportController(IGameImportService import, IWebHostEnvironment env)
    {
        _import = import;
        _env = env;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> ImportLocal()
    {
        var file = Path.Combine(_env.ContentRootPath, "Data", "games.json");
        if (!System.IO.File.Exists(file))
            return NotFound($"games.json not found at {file}");

        await using var stream = System.IO.File.OpenRead(file);
        await _import.ImportFromStreamAsync(stream);
        return Ok("Games import complete.");
    }
}
