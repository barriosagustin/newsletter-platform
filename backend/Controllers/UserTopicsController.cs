using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using backend.Data;
using backend.Entities;
using backend.DTOs;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class UserTopicsController : ControllerBase
{
    private readonly AppDbContext _context;

    public UserTopicsController(
        AppDbContext context
    )
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult GetUserTopics()
    {
        var userIdClaim =
            User.FindFirst(
                ClaimTypes.NameIdentifier
            )?.Value;

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        var userId = int.Parse(
            userIdClaim
        );

        var topics = _context.UserTopics
            .Where(ut => ut.UserId == userId)
            .Select(ut => ut.TopicId)
            .ToList();

        return Ok(topics);
    }

    [HttpPost]
    public async Task<IActionResult> AddTopic(
      [FromBody] UserTopicDto dto
  )
    {
        var userIdClaim =
            User.FindFirst(
                ClaimTypes.NameIdentifier
            )?.Value;

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        var userId = int.Parse(
            userIdClaim
        );

        var exists =
            _context.UserTopics.Any(
                ut =>
                    ut.UserId == userId &&
                    ut.TopicId == dto.TopicId
            );

        if (exists)
        {
            return BadRequest(
                "Topic already selected"
            );
        }

        var userTopic = new UserTopic
        {
            UserId = userId,
            TopicId = dto.TopicId
        };

        _context.UserTopics.Add(userTopic);

        await _context.SaveChangesAsync();

        return Ok(userTopic);
    }

    [HttpDelete("{topicId}")]
    public async Task<IActionResult> RemoveTopic(
    int topicId
)
    {
        var userIdClaim =
            User.FindFirst(
                ClaimTypes.NameIdentifier
            )?.Value;

        if (userIdClaim == null)
        {
            return Unauthorized();
        }

        var userId = int.Parse(
            userIdClaim
        );

        var userTopic =
            _context.UserTopics.FirstOrDefault(
                ut =>
                    ut.UserId == userId &&
                    ut.TopicId == topicId
            );

        if (userTopic == null)
        {
            return NotFound();
        }

        _context.UserTopics.Remove(
            userTopic
        );

        await _context.SaveChangesAsync();

        return NoContent();
    }
}