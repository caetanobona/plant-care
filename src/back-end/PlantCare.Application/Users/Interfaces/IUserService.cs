using PlantCare.Application.DTOs;
using PlantCare.Application.Users.DTOs;
using PlantCare.Application.Users.Models;
using PlantCare.Domain.Result;

namespace PlantCare.Application.Users.Interfaces;

public interface IUserService
{
    Task<Result<CreateUpdateUserDtoResponse>> CreateAsync(CreateUserRequest req);
    Task<Result<CreateUpdateUserDtoResponse>> UpdateAsync(UpdateUserRequest req);
    Task<Result> DeleteAsync(long id);
    Task<Result<List<UserDto>>> GetAllAsync();
    Task<Result<UserDto>> GetByIdAsync(long id);
    Task<bool> ExistsAsync(long id);
    Task<Result<UserDto>> GetByUsernameAsync(string username);
    Dictionary<string, bool> IsAvailable(string email, string username);
}