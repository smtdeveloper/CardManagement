using BotanoDemoCardManagement.Domain.Entities.UserEntities;

namespace BotanoDemoCardManagement.Application.Interfaces.Repositories;

public interface IJwtTokenGenerator
{
    string GenerateJwtToken(User user);
}