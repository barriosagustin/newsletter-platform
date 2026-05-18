using System.Security.Claims;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

using backend.Data;
using backend.Entities;

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

    [HttpPost]
    public async Task<IActionResult> AddTopic(
      [FromBody] int topicId
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
                    ut.TopicId == topicId
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
            TopicId = topicId
        };

        _context.UserTopics.Add(userTopic);

        await _context.SaveChangesAsync();

        return Ok(userTopic);
    }
}