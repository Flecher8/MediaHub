using MediaHub.Core.Services.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MediaHub.API.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    private readonly IUsersService _usersService;

    public UsersController(IUsersService usersService)
    {
        _usersService = usersService;
    }

    [HttpGet("by-email/{email}")]
    public async Task<IActionResult> GetUserIdByEmail(string email)
    {
        var id = await _usersService.GetUserIdByEmailAsync(email);
        if (id == null)
            return NotFound(new { Message = $"No user found with email '{email}'." });

        return Ok(new { UserId = id });
    }
}
