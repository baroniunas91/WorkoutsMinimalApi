using WorkoutsMinimalApi.Models.Requests;

namespace WorkoutsMinimalApi.Interfaces;

public interface IExerciseService
{
    Task<bool> AddAsync(ExerciseRequest exerciseRequest);
}