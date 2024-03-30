using WorkoutsMinimalApi.Interfaces;
using WorkoutsMinimalApi.Models.Requests;

namespace WorkoutsMinimalApi.Endpoints;

public static class WorkoutEndpoints
{
    public static void MapWorkoutEndpoints(this WebApplication app)
    {
        app.MapGet("workouts", GetAllWorkouts);
        app.MapGet("workouts/{id:int}", GetWorkoutById);
        app.MapPost("workouts", AddWorkout);
        app.MapDelete("workouts/{id:int}", DeleteWorkout);
        app.MapGet("workouts/{id:int}/summary", GetWorkoutSummary);
    }
    
    private static async Task<IResult> GetAllWorkouts(IWorkoutService workoutService)
    {
        var workouts = await workoutService.GetAllAsync();
        return Results.Ok(workouts);
    }
    
    private static async Task<IResult> GetWorkoutById(int id, IWorkoutService workoutService)
    {
        var workout = await workoutService.GetByIdAsync(id);
        
        return workout is null ? Results.NotFound("Workout not found") : Results.Ok(workout);
    }
    
    private static async Task<IResult> AddWorkout(WorkoutRequest workoutRequest, IWorkoutService workoutService)
    {
        var result = await workoutService.AddAsync(workoutRequest);
        return Results.Created($"/workouts/{result.Id}", result);
    }

    private static async Task<IResult> DeleteWorkout(int id, IWorkoutService workoutService)
    {
        var deleted = await workoutService.DeleteAsync(id);
        return !deleted ? Results.NotFound("Workout not found") : Results.Ok("Workout was deleted!");
    }
    
    private static async Task<IResult> GetWorkoutSummary(int id, IWorkoutService workoutService)
    {
        var summary = await workoutService.GetWorkoutSummaryAsync(id);
        
        return summary is null ? Results.NotFound("Workout not found") : Results.Ok(summary);
    }
}