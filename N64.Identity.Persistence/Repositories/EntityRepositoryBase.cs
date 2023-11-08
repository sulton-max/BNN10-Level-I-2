using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using N64.Identity.Domain.Common;
using N64.Identity.Persistence.Repositories.Interfaces;

namespace N64.Identity.Persistence.Repositories;

public abstract class EntityRepositoryBase<TEntity> : IEntityRepositoryBase<TEntity> where TEntity : class, IEntity
{
    private readonly DbContext _dbContext;

    protected EntityRepositoryBase(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public IQueryable<TEntity> Get(Expression<Func<TEntity, bool>>? predicate, bool asNoTracking = true)
    {
        var initialQuery = _dbContext.Set<TEntity>().Where(entity => true);

        if (predicate is not null)
            initialQuery = initialQuery.Where(predicate);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        return initialQuery;
    }

    public ValueTask<TEntity?> GetByIdAsync(Guid id, bool asNoTracking = true, CancellationToken cancellationToken = default)
    {
        return _dbContext.Set<TEntity>().FindAsync(new object[] {id}, cancellationToken: cancellationToken);
        
        return new(_dbContext.Set<TEntity>().AsNoTracking().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken: cancellationToken));
    }

    public async ValueTask<IList<TEntity>> GetByIdsAsync(
        IEnumerable<Guid> ids,
        bool asNoTracking = true,
        CancellationToken cancellationToken = default
    )
    {
        var initialQuery = _dbContext.Set<TEntity>().Where(entity => true);

        if (asNoTracking)
            initialQuery = initialQuery.AsNoTracking();

        initialQuery = initialQuery.Where(entity => ids.Contains(entity.Id));

        return await initialQuery.ToListAsync(cancellationToken: cancellationToken);
    }

    public async ValueTask<TEntity> CreateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        await _dbContext.Set<TEntity>().AddAsync(entity, cancellationToken);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async ValueTask<TEntity> UpdateAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        // _dbContext.Set<TEntity>()
        _dbContext.Set<TEntity>().Update(entity);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async ValueTask<TEntity?> DeleteAsync(TEntity entity, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        _dbContext.Set<TEntity>().Remove(entity);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }

    public async ValueTask<TEntity?> DeleteByIdAsync(Guid id, bool saveChanges = true, CancellationToken cancellationToken = default)
    {
        var entity = await _dbContext.Set<TEntity>().FirstOrDefaultAsync(entity => entity.Id == id, cancellationToken) ??
                     throw new InvalidOperationException();
        
        _dbContext.Set<TEntity>().Remove(entity);

        if (saveChanges)
            await _dbContext.SaveChangesAsync(cancellationToken);

        return entity;
    }
}