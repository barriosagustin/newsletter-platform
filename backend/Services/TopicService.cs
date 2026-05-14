using backend.Data;
using backend.Entities;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class TopicService : ITopicService
{
    private readonly AppDbContext _context;

    public TopicService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Topic>> GetAllTopicsAsync()
    {
        return await _context.Topics.ToListAsync();
    }

    public async Task<Topic> CreateTopicAsync(Topic topic)
    {
        _context.Topics.Add(topic);

        await _context.SaveChangesAsync();

        return topic;
    }
}