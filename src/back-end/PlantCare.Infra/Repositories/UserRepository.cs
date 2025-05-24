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
        throw new NotImplementedException();
    }

    public async Task<bool> DeleteAsync(long id)
    {
        throw new NotImplementedException();
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
        var existingUser = await _dbContext.Users.FindAsync(username);
        
        if (existingUser == null)
        {
            return false;
        }

        return true;
    }
    
    public async Task<bool> DoesEmailExist(string email)
    {
        var existingUser = await _dbContext.Users.FindAsync(email);
        
        if (existingUser == null)
        {
            return false;
        }

        return true;
    }
}