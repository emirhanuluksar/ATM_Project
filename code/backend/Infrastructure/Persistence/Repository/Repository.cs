using System.Linq.Expressions;
using Application.interfaces;
using Domain;
using Microsoft.EntityFrameworkCore;
namespace Persistence.Repository;
public class Repository<TEntity, TContext> : IRepository<TEntity>
where TEntity : class, IEntity, new()
where TContext : DbContext, new() {
    public readonly TContext _context;
    public Repository(TContext context) {
        _context = context;
    }
    public async Task AddAsync(TEntity entity) {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(TEntity entity) {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }

    public TEntity? FindById(int id) {
        return _context.Set<TEntity>().Find(id);
    }

    public async Task<TEntity?> FindByIdAsync(int id) {
        return await _context.Set<TEntity>().FindAsync(id);
    }

    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter) {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
    }

    public IList<TEntity> GetList(Expression<Func<TEntity, bool>>? filter = null) {
        return filter == null
            ? _context.Set<TEntity>().ToList()
            : _context.Set<TEntity>().Where(filter).ToList();
    }

    public async Task<IList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? filter = null) {
        return filter == null
            ? await _context.Set<TEntity>().ToListAsync()
            : await _context.Set<TEntity>().Where(filter).ToListAsync();
    }
    public async Task UpdateAsync(TEntity entity) {
        _context.Set<TEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
