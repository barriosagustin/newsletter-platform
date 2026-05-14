namespace backend.Entities;

public class NewsArticle
{
    public int Id { get; set; }

    public string Title { get; set; } = string.Empty;

    public string Content { get; set; } = string.Empty;

    public string Url { get; set; } = string.Empty;

    public string Source { get; set; } = string.Empty;

    public DateTime PublishedAt { get; set; }

    public int TopicId { get; set; }

    public Topic? Topic { get; set; }
}