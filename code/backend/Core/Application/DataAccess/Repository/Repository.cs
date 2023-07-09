using System.Linq.Expressions;
using Application.interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
namespace Persistence.Repository;
public class Repository<TDocument, TContext> : IRepository<TDocument>
where TDocument : class, IDocument, new()
where TContext : DbContext, new() {
    public readonly TContext _context = new();
    public async Task AddAsync(TDocument entity) {
        await _context.Set<TDocument>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TDocument entity) {
        _context.Set<TDocument>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public TDocument? FindById(int id) {
        return _context.Set<TDocument>().SingleOrDefault(doc => doc.Id == id);
    }

    public async Task<TDocument?> FindByIdAsync(int id) {
        return await _context.Set<TDocument>().FindAsync(id);
    }

    public TDocument? Get(Expression<Func<TDocument, bool>> filter) {
        return _context.Set<TDocument>().FirstOrDefault(filter);
    }

    public async Task<TDocument?> GetAsync(Expression<Func<TDocument, bool>> filter) {
        return await _context.Set<TDocument>().FirstOrDefaultAsync(filter);
    }

    public IList<TDocument> GetList(Expression<Func<TDocument, bool>>? filter = null) {
        return filter == null
            ? _context.Set<TDocument>().ToList()
            : _context.Set<TDocument>().Where(filter).ToList();
    }

    public IList<TDocument> GetList() {
        return _context.Set<TDocument>().ToList();
    }

    public async Task<IList<TDocument>> GetListAsync(Expression<Func<TDocument, bool>>? filter = null) {
        return filter == null
            ? await _context.Set<TDocument>().ToListAsync()
            : await _context.Set<TDocument>().Where(filter).ToListAsync();
    }
    public async Task UpdateAsync(TDocument entity) {
        _context.Set<TDocument>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
