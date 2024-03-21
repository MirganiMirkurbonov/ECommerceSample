using System.Linq.Expressions;
using Database.Interfaces;
using Database.Tables;
using Microsoft.EntityFrameworkCore;

namespace Database.Repositories;

public class GenericRepository<T>(DbContext dbContext) : IGenericRepository<T>
    where T : Entity
{
    private readonly DbSet<T> _entity = dbContext.Set<T>();

    public async Task<T?> GetById(Guid id, CancellationToken cancellationToken)
    {
        var result = await _entity.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        return result;
    }

    public async Task<T> Insert(T obj, CancellationToken cancellationToken)
    {
        var result = await _entity.AddAsync(obj, cancellationToken);
        return result.Entity;
    }

    public void Update(T obj)
    {
        _entity.Update(obj);
        dbContext.SaveChanges();
    }

    public void Delete(T entity, CancellationToken cancellationToken)
    {
        _entity.Remove(entity);
        dbContext.SaveChangesAsync(cancellationToken);
    }

    public async ValueTask<bool> Exists(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
    {
        return await _entity.AnyAsync(expression, cancellationToken);
    }

    public IQueryable<T> Query(Expression<Func<T, bool>> expression, CancellationToken cancellationToken)
    {
        var result = _entity.Where(expression);
        return result;
    }

    public IQueryable<T> Paginate(int pageSize, int pageNumber, CancellationToken cancellationToken)
    {
        var result = _entity.OrderBy(x => x.CreatedAt).Skip((pageNumber - 1) * pageSize).Take(pageSize);
        return result;
    }

    public IQueryable<T> Paginate(Expression<Func<T, bool>> expression, int pageSize, int pageNumber,
        CancellationToken cancellationToken)
    {
        var result = _entity.Where(expression)
            .OrderBy(x => x.CreatedAt) // Ensure ordering
            .Skip((pageNumber - 1) * pageSize)
            .Take(pageSize);
        return result;
    }

    public async Task SaveAsync(CancellationToken cancellationToken)
    {
        await dbContext.SaveChangesAsync(cancellationToken);
    }
}