using backend.Data;
using backend.Entities;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsersAsync()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> CreateUserAsync(User user)
    {
        _context.Users.Add(user);

        await _context.SaveChangesAsync();

        return user;
    }

    public async Task SubscribeToTopicAsync(int userId, int topicId)
    {
        var existingSubscription = await _context.UserTopics
            .FirstOrDefaultAsync(
                x => x.UserId == userId && x.TopicId == topicId
            );

        if (existingSubscription != null)
        {
            return;
        }

        var userTopic = new UserTopic
        {
            UserId = userId,
            TopicId = topicId
        };

        _context.UserTopics.Add(userTopic);

        await _context.SaveChangesAsync();
    }

    public async Task<IEnumerable<Topic>> GetUserTopicsAsync(int userId)
    {
        return await _context.UserTopics
            .Where(x => x.UserId == userId)
            .Select(x => x.Topic)
            .ToListAsync();
    }
}