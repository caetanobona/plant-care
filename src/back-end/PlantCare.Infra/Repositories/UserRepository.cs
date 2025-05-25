using Microsoft.EntityFrameworkCore;
using PlantCare.Application.Users.Interfaces;
using PlantCare.Domain.Entities;
using PlantCare.Domain.Repositories;
using PlantCare.Infra.Data;

namespace PlantCare.Infra.Repositories;

public class UserRepository : BaseRepository<User>, IUserRepository
{
    public UserRepository(PlantCareDbContext dbContext) : base(dbContext) { }

    public async Task<User?> GetByUsername(string username)
    {
        var user = await DbSet.FirstOrDefaultAsync(u => u.Username == username);
        
        return user;
    }
    
    public async Task<bool> DoesUsernameExist(string username)
    {
        var result = await DbSet.AnyAsync(u => u.Username == username);

        return result;
    }

    public async Task<bool> DoesEmailExist(string email)
    {
        var result = await DbSet.AnyAsync(u => u.Email == email);

        return result;
    }

}