using System.Data;
using System.Runtime.InteropServices.JavaScript;
using AutoMapper;
using PlantCare.Application.DTOs;
using PlantCare.Application.Users.DTOs;
using PlantCare.Application.Users.Interfaces;
using PlantCare.Application.Users.Models;
using PlantCare.Domain.Entities;
using PlantCare.Domain.Notification;
using PlantCare.Domain.Repositories;
using PlantCare.Domain.Result;

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

    public async Task<Result<CreateUpdateUserDtoResponse>> CreateAsync(CreateUserRequest req)
    {
        var notification = new Notification();
        var availability = _userRepository.IsAvailable(req.Email, req.Username);

        if (availability["Email"] == false)
        {
            notification.AddError("Email is already in use.");
        }
        
        if (availability["Username"] == false)
        {
            notification.AddError("Username is already in use.");
        }

        if (notification.HasErrors)
        {
            return Result<CreateUpdateUserDtoResponse>.Failure(notification);
        }
        
        var userEntity = _mapper.Map<User>(req);
        
        userEntity.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(req.Password, BcryptWorkFactor);
        
        var createdUser = await _userRepository.InsertAsync(userEntity);
        
        var createdUserDto = _mapper.Map<CreateUpdateUserDtoResponse>(createdUser);
        
        return Result<CreateUpdateUserDtoResponse>.Success(createdUserDto);
    }

    public async Task<Result<CreateUpdateUserDtoResponse>> UpdateAsync(UpdateUserRequest req)
    {
        var notification = new Notification();
        
        var storedUser = await _userRepository.GetByIdAsync(req.Id);

        if (storedUser == null)
        {
            notification.AddError("User not found.");
        }
        
        var availability = _userRepository.IsAvailable(req.Email, req.Username);
        
        if (req.Email is not null && availability["Email"] == false)
        {
            notification.AddError("Email is already in use.");
        }

        if (req.Username is not null && availability["Username"] == false)
        {
            notification.AddError("Username is already in use.");
        }

        if (notification.HasErrors)
        {
            return Result<CreateUpdateUserDtoResponse>.Failure(notification);
        }
        
        _mapper.Map(req, storedUser);
        
        if (!string.IsNullOrEmpty(req.Password))
        {
            storedUser!.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(req.Password, BcryptWorkFactor);
        }
        
        var patchedUser = await _userRepository.UpdateAsync(storedUser!);
        
        return Result<CreateUpdateUserDtoResponse>.Success(_mapper.Map<CreateUpdateUserDtoResponse>(patchedUser));
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
    
    public async Task<Result<List<UserDto>>> GetAllAsync()
    {
        var usersEntities = await _userRepository.GetAllAsync();
        var usersDto = _mapper.Map<List<UserDto>>(usersEntities);
        
        return Result<List<UserDto>>.Success(usersDto);
    }

    public async Task<Result<UserDto>> GetByIdAsync(long id)
    {
        var userEntity = await _userRepository.GetByIdAsync(id);
        var userDto = _mapper.Map<UserDto>(userEntity);
        
        return Result<UserDto>.Success(userDto);
    }

    public async Task<Result<UserDto>> GetByUsername(string username)
    {
        var userEntity = await _userRepository.GetByUsername(username);
        var userDto = _mapper.Map<UserDto>(userEntity);
        
        return Result<UserDto>.Success(userDto);
    }
    
    public async Task<bool> ExistsAsync(long id) => await _userRepository.ExistsAsync(id);
    public Dictionary<string, bool> IsAvailable(string email, string username) => _userRepository.IsAvailable(email, username);
}