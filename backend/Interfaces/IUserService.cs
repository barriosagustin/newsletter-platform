using backend.Entities;

namespace backend.Interfaces;


public interface IUserService
{

    Task SubscribeToTopicAsync(int userId, int topicId);

    Task<IEnumerable<Topic>> GetUserTopicsAsync(int userId);
    Task<IEnumerable<User>> GetAllUsersAsync();

    Task<User> CreateUserAsync(User user);
}