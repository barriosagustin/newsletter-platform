using backend.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace backend.Services;

public class NewsletterService
{
    private readonly AppDbContext _context;
    private readonly EmailService _emailService;

    public NewsletterService(
        AppDbContext context,
        EmailService emailService)
    {
        _context = context;
        _emailService = emailService;
    }

    public async Task SendWeeklyNewslettersAsync()
    {
        var users = await _context.Users
            .Include(u => u.UserTopics)
                .ThenInclude(ut => ut.Topic)
            .ToListAsync();

        foreach (var user in users)
        {
            var topicIds = user.UserTopics
                .Select(ut => ut.TopicId)
                .ToList();

            var news = await _context.NewsArticles
                .Where(n => topicIds.Contains(n.TopicId))
                .OrderByDescending(n => n.PublishedAt)
                .Take(5)
                .ToListAsync();

            if (!news.Any())
            {
                continue;
            }

            var html = BuildNewsletterHtml(
                user.Name,
                news
            );

            await _emailService.SendEmailAsync(
                user.Email,
                "Your Weekly AI Newsletter 🚀",
                html
            );
        }
    }

    private string BuildNewsletterHtml(
        string userName,
        List<backend.Entities.NewsArticle> news)
    {
        var sb = new StringBuilder();

        sb.Append($@"
            <h1>Hello {userName} 😄</h1>
            <p>Here are your latest news:</p>
        ");

        foreach (var article in news)
        {
            sb.Append($@"
                <hr />
                <h2>{article.Title}</h2>
                <p>{article.Content}</p>
                <a href='{article.Url}'>
                    Read more
                </a>
            ");
        }

        return sb.ToString();
    }
}