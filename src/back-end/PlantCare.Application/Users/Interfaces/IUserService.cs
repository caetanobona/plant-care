using PlantCare.Application.DTOs;

namespace PlantCare.Application.Users.Interfaces;

public interface IUserService
{
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(long id);
    Task<UserDto?> GetByUsername(string username);
}