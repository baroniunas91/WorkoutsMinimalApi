namespace WorkoutsMinimalApi.Interfaces;

/// <summary>
/// Interface to control Entity relations
/// </summary>
/// <typeparam name="TEntity"></typeparam>
public interface IEntityFilter<TEntity> where TEntity : IEntity
{
    IQueryable<TEntity> ApplyRelations(IQueryable<TEntity> queryable);
}