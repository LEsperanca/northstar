using Microsoft.EntityFrameworkCore;
using NorthStar.Domain.Abstractions;

namespace NorthStar.Infrastructure.Repositories;
internal abstract class Repository<T>
    where T : Entity
{
    protected readonly NorthStarEfCoreDbContext _dbContext;

    protected Repository(NorthStarEfCoreDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<T?> GetByIdAsync(
        Guid id,
        CancellationToken cancellationToken = default)
    {
        return await _dbContext
            .Set<T>()
            .FirstOrDefaultAsync(user => user.Id == id, cancellationToken);
    }

    public void Add(T entity)
    {
        _dbContext.Add(entity);
    }

    public void Update(T entity)
    {
        _dbContext.Update(entity);
    }

    public void Delete(T entity)
    {
        var entityEntry = _dbContext.Attach(entity);

        entityEntry.State = EntityState.Deleted;
    }
}
