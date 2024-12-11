using BotanoDemoCardManagement.Application.Features.Cards.BusinessRules;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.AddCard;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.CompleteCard;
using BotanoDemoCardManagement.Application.Features.Cards.Commands.UpdateCard;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Application.Interfaces.UnitOfWork;
using BotanoDemoCardManagement.Persistence.Context;
using BotanoDemoCardManagement.Persistence.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BotanoDemoCardManagement.Persistence;

public static class ServiceRegistration
{
    public static void AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<PostgreDbContext>(opt =>
            opt.UseNpgsql(configuration.GetConnectionString("PostgreSQLConnection"), o => o.UseNetTopologySuite()));

        services.AddScoped<ICardRepository, CardRepository>();       
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUserAnswerRepository, UserAnswerRepository>();
        services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
        services.AddScoped(typeof(IAsyncGenericRepository<>), typeof(AsyncGenericRepository<>));
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddHttpContextAccessor();
        services.AddScoped<CardBusinessRules>();
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

        services.AddValidatorsFromAssembly(typeof(ServiceRegistration).Assembly, ServiceLifetime.Scoped);        
        services.AddScoped<IValidator<AddCardCommand>, AddCardCommandValidator>();
        services.AddScoped<IValidator<UpdateCardCommand>, UpdateCardCommandValidator>();
        services.AddScoped<IValidator<CompleteCardCommand>, CompleteCardCommandValidator>();
        
        services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = configuration["JWT:Issuer"],
            ValidAudience = configuration["JWT:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]))
        };
        });

        services.AddFluentValidationAutoValidation();
        services.AddFluentValidationClientsideAdapters();


    }
}