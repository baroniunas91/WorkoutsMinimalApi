using WorkoutsMinimalApi.Filters;
using WorkoutsMinimalApi.Interfaces;
using WorkoutsMinimalApi.Models.Requests;

namespace WorkoutsMinimalApi.Endpoints;

public static class ExerciseEndpoints
{
    public static void MapExerciseEndpoints(this WebApplication app)
    {
        app.MapPost("exercises", AddExercises).AddEndpointFilter<ValidationFilter<ExerciseCreateRequest>>();
    }
    
    private static async Task<IResult> AddExercises(ExerciseCreateRequest exerciseCreateRequest, IExerciseService exerciseService)
    {
        var result = await exerciseService.AddAsync(exerciseCreateRequest);
        return result is null ? Results.NotFound("Workout was not found!") : Results.Created($"/workouts/{result.WorkoutId}", result);
    }
}