using backend.Entities;

namespace backend.Interfaces;

public interface INewsService
{
    Task<IEnumerable<NewsArticle>> GetAllAsync();

    Task<NewsArticle> CreateAsync(NewsArticle article);
}