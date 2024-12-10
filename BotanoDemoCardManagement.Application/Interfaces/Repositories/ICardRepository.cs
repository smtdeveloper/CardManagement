using BotanoDemoCardManagement.Domain.Entities.CardEntities;

namespace BotanoDemoCardManagement.Application.Interfaces.Repositories;

public interface ICardRepository : IAsyncGenericRepository<Card>
{
    Task<Card?> GetCardByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<List<Card>> GetCardAllAsync(CancellationToken cancellationToken);
}