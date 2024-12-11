using AutoMapper;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Domain.Entities.UserEntities;
using BotanoDemoCardManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace BotanoDemoCardManagement.Persistence.Repositories;

public class UserRepository : AsyncGenericRepository<User>, IUserRepository
{
    public UserRepository(PostgreDbContext context, IMapper mapper) : base(context, mapper)
    {
    }

    public async Task<User> GetByEmailAsync(string email, CancellationToken cancellationToken)
    {
        return await _context.Users
            .FirstOrDefaultAsync(u => u.Email == email, cancellationToken);
    }

}