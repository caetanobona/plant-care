using PlantCare.Application.DTOs;
using PlantCare.Application.Users.DTOs;
using PlantCare.Application.Users.Models;

namespace PlantCare.Application.Users.Interfaces;

public interface IUserService
{
    Task<CreateUpdateUserDtoResponse> CreateAsync(CreateUserRequest req);
    Task<CreateUpdateUserDtoResponse> UpdateAsync(UpdateUserRequest req);
    Task DeleteAsync(long id);
    Task<List<UserDto>> GetAllAsync();
    Task<UserDto?> GetByIdAsync(long id);
    Task<bool> ExistsAsync(long id);
    Task<UserDto?> GetByUsername(string username);
    Dictionary<string, bool> IsAvailable(string email, string username);
}