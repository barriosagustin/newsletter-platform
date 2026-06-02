namespace backend.Services;

public static class RssFeedRegistry
{
    public static List<RssFeedConfig> Feeds =>
        new()
        {
            new()
            {
                TopicId = 1,
                TopicName = "Technology",
                FeedUrl = "https://techcrunch.com/feed/"
            },

            new()
            {
                TopicId = 2,
                TopicName = "Finance",
                FeedUrl = "https://www.coindesk.com/arc/outboundfeeds/rss/"
            },

            new()
            {
                TopicId = 3,
                TopicName = "Politics",
                FeedUrl = "http://feeds.bbci.co.uk/news/politics/rss.xml"
            },

            new()
            {
                TopicId = 4,
                TopicName = "Sports",
                FeedUrl = "https://www.espn.com/espn/rss/news"
            },

            new()
            {
                TopicId = 5,
                TopicName = "AI",
                FeedUrl = "https://openai.com/news/rss.xml"
            }
        };
}