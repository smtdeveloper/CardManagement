using BotanoDemoCardManagement.Domain.Entities.UserEntities;

namespace BotanoDemoCardManagement.Application.Interfaces.Repositories;

public interface IUserRepository : IAsyncGenericRepository<User>
{
    Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken);
}