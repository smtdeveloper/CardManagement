using BotanoDemoCardManagement.Domain.Entities.UserEntities;

namespace BotanoDemoCardManagement.Application.Interfaces.Repositories;

public interface IUserAnswerRepository : IAsyncGenericRepository<UserCardAnswer>
{
    Task<UserCardAnswer?> GetUserAnswerAsync(Guid cardId, Guid questionId, CancellationToken cancellationToken);
}