using BotanoDemoCardManagement.Domain.Entities.CardEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace BotanoDemoCardManagement.Persistence.Context;

public class PostgreDbContext : DbContext
{
    public DbSet<Card> Cards { get; set; }
    public DbSet<CardQuestion> CardQuestions { get; set; }
    public DbSet<CardQuestionChoice> CardQuestionChoices { get; set; }
    public DbSet<CardType> CardTypes { get; set; }

    protected IConfiguration Configuration { get; set; }
    public PostgreDbContext(DbContextOptions<PostgreDbContext> postgreDbContextOptions, IConfiguration configuration) : base(postgreDbContextOptions)
    {
        Configuration = configuration;
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}