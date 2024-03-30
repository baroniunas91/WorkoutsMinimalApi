using AutoMapper;
using WorkoutsMinimalApi.Entities;
using WorkoutsMinimalApi.Interfaces;
using WorkoutsMinimalApi.Models;
using WorkoutsMinimalApi.Models.Requests;
using WorkoutsMinimalApi.Models.Responses;
using WorkoutsMinimalApi.Repositories;

namespace WorkoutsMinimalApi.Services;

public class WorkoutService : IWorkoutService
{
    private readonly Repository<WorkoutEntity> _workoutRepository;
    private readonly IMapper _mapper;

    public WorkoutService(Repository<WorkoutEntity> workoutRepository, IMapper mapper)
    {
        _workoutRepository = workoutRepository;
        _mapper = mapper;
    }
    
    public async Task<IEnumerable<WorkoutResponse>> GetAllAsync()
    {
        var workouts = await _workoutRepository.GetAllAsync();

        return _mapper.Map<IEnumerable<WorkoutEntity>, IEnumerable<WorkoutResponse>>(workouts);
    }
    
    public async Task<WorkoutResponse> GetByIdAsync(int id)
    {
        var workout = await _workoutRepository.FindSingleAsync(x => x.Id == id);

        var response = _mapper.Map<WorkoutEntity, WorkoutResponse>(workout);
        
        return response;
    }
    
    public async Task<WorkoutResponse> AddAsync(WorkoutRequest workoutRequest)
    {
        var newWorkout = _mapper.Map<WorkoutEntity>(workoutRequest);

        await _workoutRepository.AddAsync(newWorkout);
        await _workoutRepository.SaveChangesAsync();

        return _mapper.Map<WorkoutResponse>(newWorkout);
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var workout = await _workoutRepository.FindSingleAsync(x => x.Id == id);

        if (workout is null)
        {
            return false;
        }

        _workoutRepository.Remove(workout);
        await _workoutRepository.SaveChangesAsync();

        return true;
    }
    
    public async Task<WorkoutSummaryResponse> GetWorkoutSummaryAsync(int id)
    {
        var workout = await _workoutRepository.FindSingleAsync(x => x.Id == id);

        if (workout is null)
        {
            return null;
        }
        
        var summary = new WorkoutSummary()
        {
            WorkoutId = id,
            TotalSets = workout.Exercises.Select(x => x.Sets).Sum(),
            TotalReps = workout.Exercises.Select(x => x.Reps).Sum(),
            TotalDuration = workout.Exercises.Select(x => x.Duration).Sum()
        };
        
        return _mapper.Map<WorkoutSummaryResponse>(summary);
    }
}