using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.Interfaces;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _userService.GetAllUsersAsync();

        return Ok(users);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        var createdUser = await _userService.CreateUserAsync(user);

        return Ok(createdUser);
    }
}