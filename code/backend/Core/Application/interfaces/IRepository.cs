using System.Linq.Expressions;
using Domain;

namespace Application.interfaces;

public interface IRepository<T> where T : class, IEntity, new() {

    Task<T?> GetAsync(Expression<Func<T, bool>> filter);
    Task<IList<T>> GetListAsync(Expression<Func<T, bool>>? filter = null);
    IList<T> GetList();
    Task AddAsync(T entity);
    Task UpdateAsync(T entity);
    Task DeleteAsync(T entity);
    Task<T?> FindByIdAsync(int id);
    T? FindById(int id);
}
