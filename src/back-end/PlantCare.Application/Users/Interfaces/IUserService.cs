using PlantCare.Application.DTOs;

namespace PlantCare.Application.Users.Interfaces;

public interface IUserService
{
    Task<UserDto?> GetByIdAsync(long id);
}