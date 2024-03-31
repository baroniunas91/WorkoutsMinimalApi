using AutoMapper;
using WorkoutsMinimalApi.Entities;
using WorkoutsMinimalApi.Helpers;
using WorkoutsMinimalApi.Models;
using WorkoutsMinimalApi.Models.Requests;
using WorkoutsMinimalApi.Models.Responses;

namespace WorkoutsMinimalApi.Maps;

public class WorkoutProfile : Profile
{
    public WorkoutProfile()
    {
        CreateMap<WorkoutEntity, WorkoutResponse>();
        CreateMap<WorkoutCreateRequest, WorkoutEntity>();
        CreateMap<WorkoutSummary, WorkoutSummaryResponse>().ForMember(dest => dest.TotalDuration, opt =>
            opt.MapFrom(src => src.TotalDuration + " minutes"));
        CreateMap<WorkoutEntity, WorkoutHistoryResponse>().ForMember(dest => dest.Summary, opt =>
            opt.MapFrom(src => WorkoutHelper.CalculateWorkoutSummary(src)));
        CreateMap<WorkoutSummary, BaseWorkoutSummaryResponse>().ForMember(dest => dest.TotalDuration, opt =>
            opt.MapFrom(src => src.TotalDuration + " minutes"));
    }
}