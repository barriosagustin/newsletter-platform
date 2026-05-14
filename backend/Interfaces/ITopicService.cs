using backend.Entities;

namespace backend.Interfaces;

public interface ITopicService
{
    Task<IEnumerable<Topic>> GetAllTopicsAsync();

    Task<Topic> CreateTopicAsync(Topic topic);
}