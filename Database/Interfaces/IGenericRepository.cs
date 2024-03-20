using System.Linq.Expressions;
using Database.Tables;

namespace Database.Interfaces;

public interface IGenericRepository<T> where T : Entity // or class
{
    Task<T?> GetById(Guid id, CancellationToken cancellationToken);
    Task<T> Insert(T obj, CancellationToken cancellationToken);
    void Update(T obj);
    void Delete(T entity);
    ValueTask<bool> Exists(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
    IQueryable<T> Query(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
    IQueryable<T> Paginate(int pageSize, int pageNumber, CancellationToken cancellationToken);

    IQueryable<T> Paginate(Expression<Func<T, bool>> expression, int pageSize, int pageNumber,
        CancellationToken cancellationToken);

    Task SaveAsync(CancellationToken cancellationToken);
}