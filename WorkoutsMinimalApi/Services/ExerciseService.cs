using AutoMapper;
using WorkoutsMinimalApi.Entities;
using WorkoutsMinimalApi.Interfaces;
using WorkoutsMinimalApi.Models.Requests;
using WorkoutsMinimalApi.Repositories;

namespace WorkoutsMinimalApi.Services;

public class ExerciseService : IExerciseService
{
    private readonly Repository<ExerciseEntity> _exerciseRepository;
    private readonly Repository<WorkoutEntity> _workoutRepository;
    private readonly IMapper _mapper;

    public ExerciseService(Repository<ExerciseEntity> exerciseRepository, IMapper mapper, Repository<WorkoutEntity> workoutRepository)
    {
        _exerciseRepository = exerciseRepository;
        _mapper = mapper;
        _workoutRepository = workoutRepository;
    }

    public async Task<bool> AddAsync(ExerciseRequest exerciseRequest)
    {
        var workout = await _workoutRepository.FindSingleAsync(x => x.Id == exerciseRequest.WorkoutId);

        if (workout is null)
        {
            return false;
        }
        
        var newExercise = _mapper.Map<ExerciseEntity>(exerciseRequest);

        await _exerciseRepository.AddAsync(newExercise);
        await _exerciseRepository.SaveChangesAsync();

        return true;
    }
}