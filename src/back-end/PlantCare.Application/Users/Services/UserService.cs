using AutoMapper;
using PlantCare.Application.DTOs;
using PlantCare.Application.Users.DTOs;
using PlantCare.Application.Users.Interfaces;
using PlantCare.Application.Users.Models;
using PlantCare.Domain.Entities;
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
        var errors = new List<string>();
        var availability = _userRepository.IsAvailable(req.Email, req.Username);

        if (!availability["Email"])
        {
            errors.Add("Email is already in use.");
        }
        
        if (!availability["Username"])
        {
            errors.Add("Username is already in use.");
        }

        if (errors.Count > 0)
        {
            return Result<CreateUpdateUserDtoResponse>.Failure(errors);
        }
        
        var userEntity = _mapper.Map<User>(req);
        
        userEntity.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(req.Password, BcryptWorkFactor);
        
        var createdUser = await _userRepository.InsertAsync(userEntity);
        
        var createdUserDto = _mapper.Map<CreateUpdateUserDtoResponse>(createdUser);
        
        return Result<CreateUpdateUserDtoResponse>.Success(createdUserDto);
    }

    public async Task<Result<CreateUpdateUserDtoResponse>> UpdateAsync(UpdateUserRequest req)
    {
        var errors = new List<string>();
        
        var storedUser = await _userRepository.GetByIdAsync(req.Id);

        if (storedUser == null)
        {
            errors.Add("User not found");
        }
        
        var availability = _userRepository.IsAvailable(req.Email, req.Username);
        
        if (req.Email is not null && !availability["Email"])
        {
            errors.Add("Email is already in use.");
        }

        if (req.Username is not null && !availability["Username"])
        {
            errors.Add("Username is already in use.");
        }

        if (errors.Count > 0)
        {
            return Result<CreateUpdateUserDtoResponse>.Failure(errors);
        }
        
        _mapper.Map(req, storedUser);
        
        if (!string.IsNullOrEmpty(req.Password))
        {
            storedUser!.PasswordHash = BCrypt.Net.BCrypt.EnhancedHashPassword(req.Password, BcryptWorkFactor);
        }
        
        var patchedUser = await _userRepository.UpdateAsync(storedUser!);
        
        return Result<CreateUpdateUserDtoResponse>.Success(_mapper.Map<CreateUpdateUserDtoResponse>(patchedUser));
    }

    public async Task<Result> DeleteAsync(long id)
    {
        var existingUser = await _userRepository.GetByIdAsync(id);
        
        if (existingUser is null)
        {
            return Result.Failure("User not found");
        }

        await _userRepository.DeleteAsync(existingUser);
        return Result.Success();
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

    public async Task<Result<UserDto>> GetByUsernameAsync(string username)
    {
        var userEntity = await _userRepository.GetByUsernameAsync(username);
        
        var userDto = _mapper.Map<UserDto>(userEntity);
        return Result<UserDto>.Success(userDto);
    }
    
    public async Task<bool> ExistsAsync(long id) => await _userRepository.ExistsAsync(id);
    public Dictionary<string, bool> IsAvailable(string? email, string? username) => _userRepository.IsAvailable(email, username);
}