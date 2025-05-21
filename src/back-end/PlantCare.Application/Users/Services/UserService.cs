using PlantCare.Application.DTOs;
using PlantCare.Domain.Repositories;

namespace PlantCare.Application.Users.Services;

public class UserService
{
    private readonly IUserRepository _userRepository;
    
    public UserService( IUserRepository userRepository)
    {
        _userRepository =  userRepository;
    }

    public async Task<UserDto?> GetByIdAsync(long id)
    {
        var userEntity = await _userRepository.GetByIdAsync(id);
        var userDto = new UserDto
        {
            Email = userEntity.Email,
            Name = userEntity.Name,
            Username = userEntity.Username,
            Active = userEntity.Active
        };
        return userDto;
    }
}