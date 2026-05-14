using backend.Entities;
using backend.Interfaces;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;
    private readonly NewsIngestionService _ingestionService;


    public NewsController(
    INewsService newsService,
    NewsIngestionService ingestionService)
    {
        _newsService = newsService;
        _ingestionService = ingestionService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NewsArticle>>> GetNews()
    {
        var news = await _newsService.GetAllAsync();

        return Ok(news);
    }

    [HttpPost]
    public async Task<ActionResult<NewsArticle>> CreateNews(
        NewsArticle article)
    {
        var created = await _newsService.CreateAsync(article);

        return Ok(created);
    }

    [HttpPost("fetch")]
    public async Task<IActionResult> FetchNews()
    {
        await _ingestionService.FetchTechNewsAsync();

        return Ok("News fetched successfully");
    }
}