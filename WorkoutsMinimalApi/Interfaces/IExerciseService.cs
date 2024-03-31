using WorkoutsMinimalApi.Models.Requests;
using WorkoutsMinimalApi.Models.Responses;

namespace WorkoutsMinimalApi.Interfaces;

public interface IExerciseService
{
    Task<ExerciseCreateResponse> AddAsync(ExerciseCreateRequest exerciseCreateRequest);
}