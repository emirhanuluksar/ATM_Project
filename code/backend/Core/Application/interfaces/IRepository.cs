using System.Linq.Expressions;
using Domain;

namespace Application.interfaces;

public interface IRepository<TDocument> where TDocument : class, IDocument, new() {

    TDocument? Get(Expression<Func<TDocument, bool>> filter);
    Task<TDocument?> GetAsync(Expression<Func<TDocument, bool>> filter);
    IList<TDocument> GetList();
    IList<TDocument> GetList(Expression<Func<TDocument, bool>>? filter = null);
    Task<IList<TDocument>> GetListAsync(Expression<Func<TDocument, bool>>? filter = null);
    Task AddAsync(TDocument entity);
    Task UpdateAsync(TDocument entity);
    Task DeleteAsync(TDocument entity);
    Task<TDocument?> FindByIdAsync(int id);
    TDocument? FindById(int id);
}
