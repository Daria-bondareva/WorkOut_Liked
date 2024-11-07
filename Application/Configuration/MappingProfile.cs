using Application.DTO.Requests;
using Application.DTO.Responses;
using AutoMapper;
using Domain.Entites;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<SavedWorkout, SavedWorkoutResponse>();
        CreateMap<SavedWorkoutRequest, SavedWorkout>();

        CreateMap<User, UserResponse>();
        CreateMap<UserRequest, User>();

        CreateMap<WorkOut, WorkOutResponse>();
        CreateMap<WorkOutRequest, WorkOut>();
    }
}
