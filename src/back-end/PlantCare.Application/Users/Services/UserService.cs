using AutoMapper;
using PlantCare.Application.DTOs;
using PlantCare.Application.Users.DTOs;
using PlantCare.Application.Users.Interfaces;
using PlantCare.Application.Users.Models;
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

    public async Task<CreateUpdateUserDtoResponse> CreateAsync(CreateUserRequest req)
    {   
        var userEntity = _mapper.Map<User>(req);
        
        userEntity.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(req.Password, BcryptWorkFactor);
        
        var createdUser = await _userRepository.InsertAsync(userEntity);
        
        var createdUserDto = _mapper.Map<CreateUpdateUserDtoResponse>(createdUser);
        
        return createdUserDto;
    }

    public async Task<CreateUpdateUserDtoResponse> UpdateAsync(UpdateUserRequest req)
    {
        var storedUser = await _userRepository.GetByIdAsync(req.Id);

        if (storedUser == null)
        {
            throw new EntryPointNotFoundException();
        }
        
        _mapper.Map(req, storedUser);
        
        if (!string.IsNullOrEmpty(req.Password))
        {
            storedUser.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(req.Password, BcryptWorkFactor);
        }
        
        var patchedUser = await _userRepository.UpdateAsync(storedUser);
        
        return _mapper.Map<CreateUpdateUserDtoResponse>(patchedUser);
    }

    public async Task DeleteAsync(long id)
    {
        var existingUser = await _userRepository.ExistsAsync(id);
        
        if (!existingUser)
        {
            throw new KeyNotFoundException();
        }
        await _userRepository.DeleteAsync(id);
    }
    
    public async Task<List<UserDto>> GetAllAsync()
    {
        var usersEntities = await _userRepository.GetAllAsync();
        var usersDto = _mapper.Map<List<UserDto>>(usersEntities);
        
        return usersDto;
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

    
    public async Task<bool> DoesEmailExist(string email) => await _userRepository.DoesEmailExist(email);
    public async Task<bool> DoesUsernameExist(string username) => await _userRepository.DoesUsernameExist(username);
    public async Task<bool> ExistsAsync(long id) => await _userRepository.ExistsAsync(id);
}