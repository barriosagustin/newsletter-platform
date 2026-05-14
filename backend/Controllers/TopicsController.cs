using backend.Entities;
using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class TopicsController : ControllerBase
{
    private readonly ITopicService _topicService;

    public TopicsController(ITopicService topicService)
    {
        _topicService = topicService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Topic>>> GetTopics()
    {
        var topics = await _topicService.GetAllTopicsAsync();

        return Ok(topics);
    }

    [HttpPost]
    public async Task<ActionResult<Topic>> CreateTopic(Topic topic)
    {
        var createdTopic = await _topicService.CreateTopicAsync(topic);

        return Ok(createdTopic);
    }
}