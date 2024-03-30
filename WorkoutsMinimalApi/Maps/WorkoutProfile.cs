using AutoMapper;
using WorkoutsMinimalApi.Entities;
using WorkoutsMinimalApi.Models;
using WorkoutsMinimalApi.Models.Requests;
using WorkoutsMinimalApi.Models.Responses;

namespace WorkoutsMinimalApi.Maps;

public class WorkoutProfile : Profile
{
    public WorkoutProfile()
    {
        CreateMap<WorkoutEntity, WorkoutResponse>();
        CreateMap<WorkoutRequest, WorkoutEntity>();
        CreateMap<WorkoutSummary, WorkoutSummaryResponse>().ForMember(dest => dest.TotalDuration, opt =>
            opt.MapFrom(src => src.TotalDuration + " minutes"));;
    }
    
}