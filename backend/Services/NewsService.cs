using backend.Data;
using backend.Entities;
using backend.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace backend.Services;

public class NewsService : INewsService
{
    private readonly AppDbContext _context;

    public NewsService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<NewsArticle>> GetAllAsync()
    {
        return await _context.NewsArticles
            .Include(x => x.Topic)
            .ToListAsync();
    }

    public async Task<NewsArticle> CreateAsync(NewsArticle article)
    {
        _context.NewsArticles.Add(article);

        await _context.SaveChangesAsync();

        return article;
    }
}