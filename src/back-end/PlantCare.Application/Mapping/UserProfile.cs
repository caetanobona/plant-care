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
        CreateMap<CreateUserRequest, User>();
        CreateMap<User, CreateUpdateUserDtoResponse>();
        CreateMap<UpdateUserRequest, User>()
            .ForAllMembers(
                o => o.Condition((src, dest, srcMember) => srcMember != null));
    }
}