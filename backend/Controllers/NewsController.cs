using backend.Entities;
using backend.Interfaces;
using backend.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using backend.Data;

namespace backend.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class NewsController : ControllerBase
{
    private readonly INewsService _newsService;
    private readonly NewsIngestionService _ingestionService;

    private readonly EmailService _emailService;

    private readonly NewsletterService _newsletterService;

    private readonly AppDbContext _context;



    public NewsController(
     INewsService newsService,
     NewsIngestionService ingestionService,
     EmailService emailService,
     NewsletterService newsletterService,
    AppDbContext context
)
    {
        _newsService = newsService;
        _ingestionService = ingestionService;
        _emailService = emailService;
        _newsletterService = newsletterService;
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<NewsArticle>>> GetNews()
    {
        var news = await _newsService.GetAllAsync();

        return Ok(news);
    }

    [HttpGet("preview")]
    public IActionResult Preview()
    {
        var articles = _context.NewsArticles
            .OrderByDescending(
                n => n.PublishedAt
            )
            .Take(6)
            .Select(n => new
            {
                n.Id,
                n.Title,
                n.Source,
                n.Url,
                n.PublishedAt
            })
            .ToList();

        return Ok(articles);
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

    [HttpPost("send-test-email")]
    public async Task<IActionResult> SendTestEmail()
    {
        await _emailService.SendEmailAsync(
            "agusab2000@gmail.com",
            "Newsletter Test 🚀",
            "<h1>Hello from your SaaS 😄</h1>"
        );

        return Ok("Email sent");
    }

    [HttpPost("send-newsletters")]
    public async Task<IActionResult> SendNewsletters()
    {
        await _newsletterService.SendWeeklyNewsletters();

        return Ok("Newsletters sent");
    }
}