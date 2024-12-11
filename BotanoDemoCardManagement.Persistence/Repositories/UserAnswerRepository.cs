using AutoMapper;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Domain.Entities.UserEntities;
using BotanoDemoCardManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BotanoDemoCardManagement.Persistence.Repositories;

public class UserAnswerRepository : AsyncGenericRepository<UserCardAnswer>, IUserAnswerRepository
{
    public UserAnswerRepository(PostgreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<UserCardAnswer?> GetUserAnswerAsync(Guid cardId, Guid questionId, CancellationToken cancellationToken)
    {
        return await _context.UserCardAnswers
              .FirstOrDefaultAsync(ua => ua.CardId == cardId && ua.CardQuestionId == questionId, cancellationToken);
    }
}