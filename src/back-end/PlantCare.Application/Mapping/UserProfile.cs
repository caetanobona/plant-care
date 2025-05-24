using AutoMapper;
using PlantCare.Application.DTOs;
using PlantCare.Application.Users.DTOs;
using PlantCare.Application.Users.Models;
using PlantCare.Domain.Entities;

namespace PlantCare.Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<CreateUserRequest, User>()
            .ForMember(dest => dest.Active, o => o
                .MapFrom(src => true));
        CreateMap<User, CreateUpdateUserDtoResponse>();
        CreateMap<UpdateUserRequest, User>()
            .ForMember(
                dest => dest.Active, o => o
                    .MapFrom(src => true))
            .ForAllMembers(
                o => o
                    .Condition((src, dest, srcMember) => srcMember != null));
    }
}