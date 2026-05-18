using Microsoft.AspNetCore.Mvc;
using backend.Entities;
using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using backend.Data;
using backend.DTOs;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    private readonly AppDbContext _context;

    public UsersController(
    IUserService userService,
    AppDbContext context
)
    {
        _userService = userService;
        _context = context;
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

    [HttpGet("me")]
    public IActionResult GetCurrentUser()
    {
        var userId = int.Parse(
            User.FindFirst(
                ClaimTypes.NameIdentifier
            )!.Value
        );

        var user = _context.Users
            .Where(u => u.Id == userId)
            .Select(u => new
            {
                u.Id,
                u.Name,
                u.Email,
                u.Role,
                u.NewsletterEnabled,
                u.NewsletterFrequency
            })
            .FirstOrDefault();

        return Ok(user);
    }

    [HttpPut("newsletter-settings")]
    public async Task<IActionResult>
        UpdateNewsletterSettings(
            UpdateNewsletterSettingsDto dto
        )
    {
        var userId = int.Parse(
            User.FindFirst(
                ClaimTypes.NameIdentifier
            )!.Value
        );

        var user =
            await _context.Users.FindAsync(
                userId
            );

        if (user == null)
        {
            return NotFound();
        }

        user.NewsletterEnabled =
            dto.NewsletterEnabled;

        user.NewsletterFrequency =
            dto.NewsletterFrequency;

        await _context.SaveChangesAsync();

        return Ok(user);
    }
}