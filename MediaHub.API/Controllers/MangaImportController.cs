using MediaHub.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class MangaImportController : ControllerBase
{
    private readonly IMangaImportService _import;
    private readonly IWebHostEnvironment _env;

    public MangaImportController(IMangaImportService import, IWebHostEnvironment env)
    {
        _import = import;
        _env = env;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> ImportLocal()
    {
        var filePath = Path.Combine(_env.ContentRootPath, "Data", "manga.json");
        if (!System.IO.File.Exists(filePath))
            return NotFound($"manga.json not found at {filePath}");

        await using var stream = System.IO.File.OpenRead(filePath);
        await _import.ImportFromStreamAsync(stream);
        return Ok("Manga import complete.");
    }
}
