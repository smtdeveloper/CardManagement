using BotanoDemoCardManagement.Application.Features.Cards.BusinessRules;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Application.Interfaces.UnitOfWork;
using BotanoDemoCardManagement.Persistence.Context;
using BotanoDemoCardManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BotanoDemoCardManagement.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {

        services.AddDbContext<PostgreDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"), o => o.UseNetTopologySuite()));

        services.AddScoped<ICardRepository, CardRepository>();       
        services.AddScoped<IUserAnswerRepository, UserAnswerRepository>();       
        services.AddScoped(typeof(IAsyncGenericRepository<>), typeof(AsyncGenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();

        // Register business rules
        services.AddScoped<CardBusinessRules>();

        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }
}