using BotanoDemoCardManagement.Application.Interfaces.UnitOfWork;
using BotanoDemoCardManagement.Persistence.Context;

namespace BotanoDemoCardManagement.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly PostgreDbContext _context;
    public UnitOfWork(PostgreDbContext context)
    {
        _context = context;
    }
    public void Commit()
    {
        _context.SaveChanges();
    }

    public async Task CommitAsync()
    {
        await _context.SaveChangesAsync();
    }
}