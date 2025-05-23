using AutoMapper;
using PlantCare.Application.DTOs;
using PlantCare.Domain.Entities;

namespace PlantCare.Application.Mapping;

public class UserProfile : Profile
{
    public UserProfile()
    {
        CreateMap<User, UserDto>();
        CreateMap<CreateUserDtoRequest, User>();
        CreateMap<User, CreateUserDtoResponse>();
    }
}