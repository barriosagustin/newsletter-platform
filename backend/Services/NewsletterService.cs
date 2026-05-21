using Microsoft.EntityFrameworkCore;

using backend.Data;
using backend.Entities;
namespace backend.Services;

public class NewsletterService
{
    private readonly AppDbContext _context;

    private readonly EmailService _emailService;

    public NewsletterService(
        AppDbContext context,
        EmailService emailService
    )
    {
        _context = context;
        _emailService = emailService;
    }

    public async Task SendWeeklyNewsletters()
    {
        var users = await _context.Users
            .Include(u => u.UserTopics)
            .ThenInclude(ut => ut.Topic)
            .Where(u => u.NewsletterEnabled)
            .ToListAsync();

        foreach (var user in users)
        {
            var topicIds = user.UserTopics
                .Select(ut => ut.TopicId)
                .ToList();

            var articles =
                await _context.NewsArticles
                    .Where(n =>
                        topicIds.Contains(
                            n.TopicId
                        )
                    )
                    .OrderByDescending(
                        n => n.PublishedAt
                    )
                    .Take(10)
                    .ToListAsync();

            if (!articles.Any())
            {
                continue;
            }

            var html =
                GenerateNewsletterHtml(
                    user.Name,
                    articles
                );

            await _emailService.SendEmailAsync(
                user.Email,
                "Your Weekly Newsletter 🚀",
                html
            );
        }
    }

    private string GenerateNewsletterHtml(
      string userName,
      List<NewsArticle> articles
  )
    {
        var articlesHtml = string.Join(
            "",
            articles.Select(a =>
                $@"
            <div style='background:#111827;border:1px solid #1f2937;border-radius:20px;padding:24px;margin-bottom:20px'>
                <p style='color:#9ca3af;font-size:14px;margin:0'>
                    {a.Source}
                </p>

                <h2 style='color:white;font-size:24px;margin-top:12px'>
                    {a.Title}
                </h2>

                <a
                    href='{a.Url}'
                    style='display:inline-block;margin-top:16px;color:white;background:#2563eb;padding:12px 20px;border-radius:12px;text-decoration:none;font-weight:bold'
                >
                    Read article
                </a>
            </div>
        "
            )
        );

        return $@"
        <div style='background:#030712;padding:40px;font-family:Arial,sans-serif'>
            <div style='max-width:700px;margin:0 auto'>
                <div style='margin-bottom:40px'>
                    <h1 style='color:white;font-size:42px;margin:0'>
                        Newsletter Platform 🚀
                    </h1>

                    <p style='color:#9ca3af;font-size:18px;margin-top:12px'>
                        Personalized news for {userName}
                    </p>
                </div>

                {articlesHtml}

                <div style='margin-top:40px;text-align:center'>
                    <p style='color:#6b7280;font-size:14px'>
                        Generated automatically by your personalized newsletter engine.
                    </p>
                </div>
            </div>
        </div>
    ";
    }
}