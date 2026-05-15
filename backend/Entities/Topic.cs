namespace backend.Entities;

public class Topic
{
    public int Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public List<UserTopic> UserTopics { get; set; } = [];
}