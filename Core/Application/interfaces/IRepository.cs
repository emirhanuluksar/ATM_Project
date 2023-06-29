using System.Linq.Expressions;
using Domain;

namespace Application.interfaces;

public interface IRepository<T> where T : class, IEntity, new() {

    Task<T?> GetAsync(Expression<Func<T, bool>> filter);
    Task<IList<T>> GetListAsync(Expression<Func<T, bool>>? filter = null);
    Task Add(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
}
