using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
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

    /// <summary>
    /// Subscribes the authenticated user to a topic.
    /// </summary>

    [HttpPost("topics/{topicId}")]
    public async Task<IActionResult> SubscribeToTopic(int topicId)
    {
        var userId = int.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        );

        await _userService.SubscribeToTopicAsync(userId, topicId);

        return Ok();
    }

    [HttpGet("my-topics")]
    public async Task<ActionResult<IEnumerable<Topic>>> GetMyTopics()
    {
        var userId = int.Parse(
            User.FindFirst(ClaimTypes.NameIdentifier)!.Value
        );

        var topics = await _userService.GetUserTopicsAsync(userId);

        return Ok(topics);
    }
}