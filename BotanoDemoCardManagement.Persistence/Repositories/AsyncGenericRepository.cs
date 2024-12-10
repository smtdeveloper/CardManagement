using AutoMapper;
using AutoMapper.QueryableExtensions;
using BotanoDemoCardManagement.Application.Interfaces.Repositories;
using BotanoDemoCardManagement.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace BotanoDemoCardManagement.Persistence.Repositories;
public class AsyncGenericRepository<TEntity> : IAsyncGenericRepository<TEntity> where TEntity : class
{

    protected readonly PostgreDbContext _context;
    protected readonly IMapper _mapper;
    private DbSet<TEntity> _dbSet;

    public AsyncGenericRepository(PostgreDbContext context, IMapper mapper)
    {
        _context = context ?? throw new ArgumentNullException(nameof(context));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _dbSet = _context.Set<TEntity>();
    }

    public async Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken)
    {
        if (entity == null)
        {
            throw new ArgumentNullException(nameof(entity), "Entity cannot be null.");
        }
        await _dbSet.AddAsync(entity);
        return entity;
    }

    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken)
    {
        await _dbSet.AddRangeAsync(entities);
    }

    public async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken)
    {
        return await _dbSet.AnyAsync(expression);
    }

    public async Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Remove(TEntity entity)
    {
        _dbSet.Remove(entity);
    }

    public async Task<TEntity> Update(TEntity entity)
    {
        _dbSet.Update(entity);
        return entity;
    }

    public async Task<ICollection<TEntity>> GetAllAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>>? expression = null)
    {
        var result = _dbSet.AsQueryable();

        if (expression != null)
            result = result.Where(expression);

        return await result.ToListAsync(cancellationToken);
    }

    public async Task<ICollection<TProjectionDto>> GetAllAsync<TProjectionDto>(CancellationToken cancellationToken, Expression<Func<TProjectionDto, bool>>? expression = null)
    {
        var query = _dbSet.AsQueryable().ProjectTo<TProjectionDto>(_mapper.ConfigurationProvider);
        if (expression is not null)
            query = query.Where(expression);

        return await query.ToListAsync(cancellationToken: cancellationToken);
    }
}