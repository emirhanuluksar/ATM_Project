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
    public async Task Add(TEntity entity) {
        await _context.Set<TEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(TEntity entity) {
        _context.Set<TEntity>().Remove(entity);
        await _context.SaveChangesAsync();
    }
    public async Task<TEntity?> GetAsync(Expression<Func<TEntity, bool>> filter) {
        return await _context.Set<TEntity>().FirstOrDefaultAsync(filter);
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
