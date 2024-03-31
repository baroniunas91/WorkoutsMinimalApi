using WorkoutsMinimalApi.Entities;
using WorkoutsMinimalApi.Models;

namespace WorkoutsMinimalApi.Helpers;

public static class WorkoutHelper
{
    public static WorkoutSummary CalculateWorkoutSummary(WorkoutEntity workoutEntity)
    {
        return new WorkoutSummary()
        {
            WorkoutId = workoutEntity.Id,
            TotalSets = workoutEntity.Exercises.Select(x => x.Sets).Sum(),
            TotalReps = workoutEntity.Exercises.Select(x => x.Reps).Sum(),
            TotalDuration = workoutEntity.Exercises.Select(x => x.Duration).Sum()
        };
    }
}