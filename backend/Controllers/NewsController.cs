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

    private readonly EmailService _emailService;

    private readonly NewsletterService _newsletterService;


    public NewsController(
     INewsService newsService,
     NewsIngestionService ingestionService,
     EmailService emailService,
     NewsletterService newsletterService)
    {
        _newsService = newsService;
        _ingestionService = ingestionService;
        _emailService = emailService;
        _newsletterService = newsletterService;
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
        await _newsletterService.SendWeeklyNewslettersAsync();

        return Ok("Newsletters sent");
    }
}