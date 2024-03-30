using WorkoutsMinimalApi.Entities;
using WorkoutsMinimalApi.Interfaces;

namespace WorkoutsMinimalApi.Filters;

public class ExerciseEntityFilter : IEntityFilter<ExerciseEntity>
{
    public IQueryable<ExerciseEntity> ApplyRelations(IQueryable<ExerciseEntity> queryable)
    {
        return queryable;
    }
}