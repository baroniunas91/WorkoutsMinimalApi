using AutoMapper;
using WorkoutsMinimalApi.Entities;
using WorkoutsMinimalApi.Models.Requests;
using WorkoutsMinimalApi.Models.Responses;

namespace WorkoutsMinimalApi.Maps;

public class ExerciseProfile : Profile
{
    public ExerciseProfile()
    {
        CreateMap<ExerciseEntity, ExerciseResponse>().ForMember(dest => dest.Duration, opt =>
            opt.MapFrom(src => src.Duration + " minutes"));
        CreateMap<ExerciseCreateRequest, ExerciseEntity>();
        CreateMap<ExerciseEntity, ExerciseCreateResponse>().ForMember(dest => dest.Duration, opt =>
            opt.MapFrom(src => src.Duration + " minutes"));
    }
}