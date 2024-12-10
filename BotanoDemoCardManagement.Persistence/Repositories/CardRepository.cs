using AutoMapper;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Domain.Entities.CardEntities;
using BotanoDemoCardManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using System.Linq;

namespace BotanoDemoCardManagement.Persistence.Repositories;

public class CardRepository : AsyncGenericRepository<Card>, ICardRepository
{
    public CardRepository(PostgreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<List<Card>> GetCardAllAsync(CancellationToken cancellationToken)
    {
        return await _context.Cards
       .Include(_card => _card.CardType)
       .Include(_card => _card.Questions)
       .ThenInclude(_cardQuestion => _cardQuestion.Choices).
       Where(_card => _card.IsDelete == false)
       .ToListAsync(cancellationToken);
    }

    public async Task<Card?> GetCardByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _context.Cards
       .Include(_card => _card.CardType)
       .Include(_card => _card.Questions)
       .ThenInclude(_cardQuestion => _cardQuestion.Choices)
       .FirstOrDefaultAsync(_card => _card.Id == id, cancellationToken);
    }
}