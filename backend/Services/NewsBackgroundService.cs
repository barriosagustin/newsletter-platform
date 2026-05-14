using Microsoft.Extensions.DependencyInjection;

namespace backend.Services;

public class NewsBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;

    public NewsBackgroundService(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    protected override async Task ExecuteAsync(
        CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            using var scope = _serviceProvider.CreateScope();

            var ingestionService =
                scope.ServiceProvider
                    .GetRequiredService<NewsIngestionService>();

            Console.WriteLine("Fetching news...");

            await ingestionService.FetchTechNewsAsync();

            Console.WriteLine("News fetched!");

            await Task.Delay(
                TimeSpan.FromMinutes(30),
                stoppingToken
            );
        }
    }
}