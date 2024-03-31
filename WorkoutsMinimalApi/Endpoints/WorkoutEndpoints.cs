using WorkoutsMinimalApi.Filters;
using WorkoutsMinimalApi.Interfaces;
using WorkoutsMinimalApi.Models.Requests;

namespace WorkoutsMinimalApi.Endpoints;

public static class WorkoutEndpoints
{
    public static void MapWorkoutEndpoints(this WebApplication app)
    {
        app.MapGet("workouts", GetAllWorkouts);
        app.MapGet("workouts/{id:int}", GetWorkoutById);
        app.MapPost("workouts", AddWorkout).AddEndpointFilter<ValidationFilter<WorkoutCreateRequest>>();;
        app.MapDelete("workouts/{id:int}", DeleteWorkout);
        app.MapGet("workouts/{id:int}/summary", GetWorkoutSummary);
        app.MapPut("workouts/{id:int}", LinkWorkoutDate).AddEndpointFilter<ValidationFilter<WorkoutUpdateRequest>>();;
        app.MapGet("workouts/history/{date:datetime}", GetWorkoutsHistoryByDate);
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
    
    private static async Task<IResult> AddWorkout(WorkoutCreateRequest workoutCreateRequest, IWorkoutService workoutService)
    {
        var result = await workoutService.AddAsync(workoutCreateRequest);
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
    
    private static async Task<IResult> LinkWorkoutDate(int id, WorkoutUpdateRequest workoutUpdateRequest, IWorkoutService workoutService)
    {
        var updated = await workoutService.LinkWorkoutDateAsync(id, workoutUpdateRequest);
        
        return !updated ? Results.NotFound("Workout not found") : Results.Ok("Date linked to workout!");
    }
    
    private static async Task<IResult> GetWorkoutsHistoryByDate(DateTime date, IWorkoutService workoutService)
    {
        var history = await workoutService.GetWorkoutsHistoryByDateAsync(date);
        
        return history is null ? Results.NotFound("Workouts not found") : Results.Ok(history);
    }
}