using MediaHub.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class SerialImportController : ControllerBase
{
    private readonly ISerialImportService _import;
    private readonly IWebHostEnvironment _env;

    public SerialImportController(ISerialImportService import, IWebHostEnvironment env)
    {
        _import = import;
        _env = env;
    }

    [HttpPost("upload")]
    public async Task<IActionResult> ImportLocal()
    {
        var filePath = Path.Combine(_env.ContentRootPath, "Data", "serials.json");
        if (!System.IO.File.Exists(filePath))
            return NotFound($"serials.json not found at {filePath}");

        await using var stream = System.IO.File.OpenRead(filePath);
        await _import.ImportFromStreamAsync(stream);
        return Ok("Serial import complete.");
    }
}
