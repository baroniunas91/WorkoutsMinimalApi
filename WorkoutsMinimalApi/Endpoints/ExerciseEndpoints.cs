using WorkoutsMinimalApi.Interfaces;
using WorkoutsMinimalApi.Models.Requests;

namespace WorkoutsMinimalApi.Endpoints;

public static class ExerciseEndpoints
{
    public static void MapExerciseEndpoints(this WebApplication app)
    {
        app.MapPost("exercises", AddExercises);
    }
    
    private static async Task<IResult> AddExercises(ExerciseRequest exerciseRequest, IExerciseService exerciseService)
    {
        var result = await exerciseService.AddAsync(exerciseRequest);

        return !result ? Results.NotFound("Workout was not found!") : Results.Ok("Exercise created");
    }
}