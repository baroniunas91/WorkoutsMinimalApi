using Microsoft.EntityFrameworkCore;
using WorkoutsMinimalApi.Entities;
using WorkoutsMinimalApi.Interfaces;

namespace WorkoutsMinimalApi.Filters;

public class WorkoutEntityFilter : IEntityFilter<WorkoutEntity>
{
    public IQueryable<WorkoutEntity> ApplyRelations(IQueryable<WorkoutEntity> queryable)
    {
        return queryable.Include(x => x.Exercises);
    }
}