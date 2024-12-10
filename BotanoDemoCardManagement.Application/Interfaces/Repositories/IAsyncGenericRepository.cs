using System.Linq.Expressions;

namespace BotanoDemoCardManagement.Application.Interfaces.Repositories;

public interface IAsyncGenericRepository<TEntity> where TEntity : class
{
    Task<TEntity> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<ICollection<TEntity>> GetAllAsync(CancellationToken cancellationToken, Expression<Func<TEntity, bool>>? expression = null);
    Task<ICollection<TResponse>> GetAllAsync<TResponse>(CancellationToken cancellationToken, Expression<Func<TResponse, bool>>? expression = null);
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> expression, CancellationToken cancellationToken);
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken);
    Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellationToken);
    Task<TEntity> Update(TEntity entity);   
    void Remove(TEntity entity);  
}