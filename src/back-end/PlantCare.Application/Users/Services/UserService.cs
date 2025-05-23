using AutoMapper;
using PlantCare.Application.DTOs;
using PlantCare.Application.Users.Interfaces;
using PlantCare.Domain.Entities;
using PlantCare.Domain.Repositories;

namespace PlantCare.Application.Users.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IMapper _mapper;
    
    private const int BcryptWorkFactor = 12;

    public UserService(IUserRepository userRepository, IMapper mapper)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    public async Task<CreateUserDtoResponse> CreateAsync(CreateUserRequest req)
    {
        var userEntity = _mapper.Map<User>(req);
        
        userEntity.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(req.Password, BcryptWorkFactor);
        
        var createdUser = await _userRepository.InsertAsync(userEntity);
        
        var createdUserDto = _mapper.Map<CreateUserDtoResponse>(createdUser);
        
        return createdUserDto;
    }

    public async Task<List<UserDto>> GetAllAsync()
    {
        var usersEntities = await _userRepository.GetAllAsync();
        var usersDtos = _mapper.Map<List<UserDto>>(usersEntities);

        if (usersDtos != null)
        {
            Console.WriteLine($"User GetAllAsync Response {usersDtos.Count} users");
        }
        
        return usersDtos;
    }

    public async Task<UserDto?> GetByIdAsync(long id)
    {
        var userEntity = await _userRepository.GetByIdAsync(id);
        var userDto = _mapper.Map<UserDto>(userEntity);
        
        return userDto;
    }

    public async Task<UserDto?> GetByUsername(string username)
    {
        var userEntity = await _userRepository.GetByUsername(username);
        var userDto = _mapper.Map<UserDto>(userEntity);
        
        return userDto;
    }

}