using backend.Services;
using Hangfire;

namespace backend.Jobs;

public class NewsJobs
{
    private readonly IServiceProvider _serviceProvider;

    public NewsJobs(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public void RegisterJobs()
    {
        RecurringJob.AddOrUpdate(
            "fetch-news-job",
            () => Execute(),
            Cron.Minutely
        );
    }

    public async Task Execute()
    {
        using var scope = _serviceProvider.CreateScope();

        var ingestion = scope.ServiceProvider
            .GetRequiredService<NewsIngestionService>();

        await ingestion.FetchTechNewsAsync();

        Console.WriteLine("Hangfire: news fetched 😄");
    }
}