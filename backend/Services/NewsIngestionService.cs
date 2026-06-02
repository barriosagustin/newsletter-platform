using System.ServiceModel.Syndication;
using System.Xml;

using backend.Data;
using backend.Entities;

using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class NewsIngestionService
{
    private readonly AppDbContext _context;

    public NewsIngestionService(
        AppDbContext context
    )
    {
        _context = context;
    }

    public async Task FetchNewsAsync()
    {
        foreach (
            var feedConfig
            in RssFeedRegistry.Feeds
        )
        {
            try
            {
                using var reader =
                    XmlReader.Create(
                        feedConfig.FeedUrl
                    );

                var feed =
                    SyndicationFeed.Load(
                        reader
                    );

                if (feed == null)
                {
                    continue;
                }

                foreach (
                    var item
                    in feed.Items.Take(10)
                )
                {
                    var url =
                        item.Links
                            .FirstOrDefault()
                            ?.Uri.ToString();

                    if (
                        string.IsNullOrEmpty(
                            url
                        )
                    )
                    {
                        continue;
                    }

                    var exists =
                        await _context.NewsArticles
                            .AnyAsync(x =>
                                x.Url == url
                            );

                    if (exists)
                    {
                        continue;
                    }

                    var article =
                        new NewsArticle
                        {
                            Title =
                                item.Title.Text,

                            Content =
                                item.Summary?.Text
                                ?? "",

                            Url = url,

                            Source =
                                feed.Title.Text,

                            PublishedAt =
                                item.PublishDate.UtcDateTime,

                            TopicId =
                                feedConfig.TopicId
                        };

                    _context.NewsArticles
                        .Add(article);

                    Console.WriteLine(
                        $"Added article: {article.Title}"
                    );
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(
                    $"RSS Error: {feedConfig.TopicName}"
                );

                Console.WriteLine(
                    ex.Message
                );
            }
        }

        await _context.SaveChangesAsync();
    }
}