using System.ServiceModel.Syndication;
using System.Xml;
using backend.Data;
using backend.Entities;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class NewsIngestionService
{
    private readonly AppDbContext _context;

    public NewsIngestionService(AppDbContext context)
    {
        _context = context;
    }

    public async Task FetchTechNewsAsync()
    {
        using var reader = XmlReader.Create(
            "https://techcrunch.com/feed/"
        );

        var feed = SyndicationFeed.Load(reader);

        if (feed == null)
        {
            return;
        }

        foreach (var item in feed.Items.Take(10))
        {
            var url = item.Links.FirstOrDefault()?.Uri.ToString();

            if (string.IsNullOrEmpty(url))
            {
                continue;
            }

            var existingArticle = await _context.NewsArticles
                .FirstOrDefaultAsync(x => x.Url == url);

            if (existingArticle != null)
            {
                continue;
            }

            var topic = await _context.Topics
                .FirstOrDefaultAsync(x => x.Name == "AI");

            if (topic == null)
            {
                continue;
            }

            var article = new NewsArticle
            {
                Title = item.Title.Text,
                Content = item.Summary?.Text ?? "",
                Url = url,
                Source = "TechCrunch",
                PublishedAt = item.PublishDate.UtcDateTime,
                TopicId = topic.Id
            };

            _context.NewsArticles.Add(article);
        }

        await _context.SaveChangesAsync();
    }
}