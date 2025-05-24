using Microsoft.EntityFrameworkCore;
using PlantCare.Application.Context;
using PlantCare.Application.Users.Interfaces;
using PlantCare.Domain.Entities;
using PlantCare.Domain.Repositories;

namespace PlantCare.Infra.Repositories;

public class UserRepository : IUserRepository
{

    private readonly IPlantCareDbContext _dbContext;
    
    public UserRepository( IPlantCareDbContext context )
    {
        _dbContext = context;
    }
    
    public async Task<User?> InsertAsync(User obj)
    {
        var newUser = await _dbContext.Users.AddAsync(obj);
        await _dbContext.SaveChangesAsync();
        
        return newUser.Entity;
    }

    public async Task<User?> UpdateAsync(User obj)
    {
        var updatedUser = _dbContext.Users.Update(obj);
        
        await _dbContext.SaveChangesAsync();
        
        return updatedUser.Entity;
    }
    
    public async Task<bool> DeleteAsync(long id)
    {
        var user = await _dbContext.Users.FindAsync(id);

        if (user == null)
        {
            return false;
        }
            
        user.Active = false;
        _dbContext.Users.Update(user);
        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<List<User>> GetAllAsync()
    {
        var users = await _dbContext.Users.ToListAsync();

        if (users != null)
        {
            Console.WriteLine($"User GetAllAsync Response {users.Count} users");
        }
        
        return users;
    }

    public async Task<User?> GetByIdAsync(long id)
    {
        var user = await _dbContext.Users.FindAsync(id);
        
        return user;
    }

    public async Task<User?> GetByUsername(string username)
    {
        var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Username == username);
        
        return user;
    }
    
    public async Task<bool> DoesUsernameExist(string username)
    {
        var result = await _dbContext.Users.AnyAsync(u => u.Username == username);
        
        Console.WriteLine($"checking username {username} = {result}");

        return result;
    }

    public async Task<bool> DoesEmailExist(string email)
    {
        var result = await _dbContext.Users.AnyAsync(u => u.Email == email);
        
        Console.WriteLine($"checking email {email} - {result}");

        return result;
    }

    public async Task<bool> ExistsAsync(long id)
    {
        var result = await _dbContext.Users.FindAsync(id);
        
        return result != null;
    }
}