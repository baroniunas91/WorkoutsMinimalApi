using WorkoutsMinimalApi.Models;
using WorkoutsMinimalApi.Models.Requests;
using WorkoutsMinimalApi.Models.Responses;

namespace WorkoutsMinimalApi.Interfaces;

public interface IWorkoutService
{
    Task<IEnumerable<WorkoutResponse>> GetAllAsync();
    Task<WorkoutResponse> GetByIdAsync(int id);
    Task<WorkoutResponse> AddAsync(WorkoutCreateRequest workoutCreateRequest);
    Task<bool> DeleteAsync(int id);
    Task<WorkoutSummaryResponse> GetWorkoutSummaryAsync(int id);
    Task<bool> LinkWorkoutDateAsync(int id, WorkoutUpdateRequest workoutUpdateRequest);
    Task<WorkoutCalenderResponse> GetWorkoutsHistoryByDateAsync(DateTime date);
}