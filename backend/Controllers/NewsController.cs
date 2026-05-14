using backend.Entities;
using backend.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;

    public NewsController(INewsService newsService)
    {
        _newsService = newsService;
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
}