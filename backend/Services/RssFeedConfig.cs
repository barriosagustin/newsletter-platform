namespace backend.Services;

public class RssFeedConfig
{
    public int TopicId { get; set; }

    public string TopicName { get; set; } = string.Empty;

    public string FeedUrl { get; set; } = string.Empty;
}