using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WorkoutsMinimalApi.ContextConfigurations;
using WorkoutsMinimalApi.Interfaces;

namespace WorkoutsMinimalApi.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
{
    private readonly MyDbContext _context;
    private readonly IEntityFilter<TEntity> _entityFilter;

    public Repository(MyDbContext context,
        IEntityFilter<TEntity> entityFilter)
    {
        _context = context;
        _entityFilter = entityFilter;
    }
    public async Task<IEnumerable<TEntity>> GetAllAsync()
    {
        var query = _context.Set<TEntity>().AsQueryable();
        query = _entityFilter.ApplyRelations(query);
        return await query.ToListAsync();
    }

    public async Task<TEntity> FindSingleAsync(Expression<Func<TEntity, bool>> expression)
    {
        var query = _context.Set<TEntity>().AsQueryable().Where(expression);
        query = _entityFilter.ApplyRelations(query);
        return await query.FirstOrDefaultAsync();
    }

    public async Task AddAsync(TEntity entity)
    {
        await _context.Set<TEntity>().AddAsync(entity);
    }

    public void Remove(TEntity entity)
    {
        _context.Set<TEntity>().Remove(entity);
    }
    
    public async Task<IEnumerable<TEntity>> FindAsync(Expression<Func<TEntity, bool>> expression)
    {
        var query = _context.Set<TEntity>().AsQueryable();
        query = _entityFilter.ApplyRelations(query);
        return await query.Where(expression).ToListAsync();
    }
    
    public void Update(TEntity entity)
    {
        _context.Set<TEntity>().Update(entity);
    }
    
    public async Task SaveChangesAsync()
    {
        await _context.SaveChangesAsync();
    }
}