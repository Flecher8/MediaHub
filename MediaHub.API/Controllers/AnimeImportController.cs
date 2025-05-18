using MediaHub.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class AnimeImportController : ControllerBase
{
    private readonly IAnimeImportService _import;
    private readonly IWebHostEnvironment _env;

    public AnimeImportController(
        IAnimeImportService import,
        IWebHostEnvironment env)
    {
        _import = import;
        _env = env;
    }

    /// <summary>
    /// POST api/animeimport/local
    /// Reads the local Data/anime.json file and imports it.
    /// </summary>
    [HttpPost("upload")]
    public async Task<IActionResult> ImportLocalFile()
    {
        // 1) build the absolute path
        var filePath = Path.Combine(_env.ContentRootPath, "Data", "anime.json");

        if (!System.IO.File.Exists(filePath))
            return NotFound($"File not found at {filePath}");

        // 2) open and import
        await using var stream = System.IO.File.OpenRead(filePath);
        await _import.ImportFromStreamAsync(stream);

        return Ok("Imported anime.json from local Data folder.");
    }
}
