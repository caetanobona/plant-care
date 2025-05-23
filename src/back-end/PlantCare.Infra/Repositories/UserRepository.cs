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
    
    public async Task InsertAsync(User obj)
    {
        throw new NotImplementedException();
    }

    public async Task UpdateAsync(User obj)
    {
        throw new NotImplementedException();
    }

    public async Task DeleteAsync(long id)
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
}