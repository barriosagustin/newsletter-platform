using Microsoft.EntityFrameworkCore;
using backend.Entities;

namespace backend.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserTopic>()
            .HasKey(ut => new { ut.UserId, ut.TopicId });

        modelBuilder.Entity<UserTopic>()
            .HasOne(ut => ut.User)
            .WithMany(u => u.UserTopics)
            .HasForeignKey(ut => ut.UserId);

        modelBuilder.Entity<UserTopic>()
            .HasOne(ut => ut.Topic)
            .WithMany(t => t.UserTopics)
            .HasForeignKey(ut => ut.TopicId);
    }

    public DbSet<User> Users => Set<User>();

    public DbSet<Topic> Topics { get; set; }

    public DbSet<UserTopic> UserTopics { get; set; }

    public DbSet<NewsArticle> NewsArticles { get; set; }
}