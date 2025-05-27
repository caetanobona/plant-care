using System.Runtime.InteropServices.JavaScript;
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
    
    public Dictionary<string, bool> IsAvailable(string? email, string? username)
    {
        var query = DbSet
            .Where(u => u.Email == email || u.Username == username)
            .Select(u => new { u.Email, u.Username })
            .ToList();
        
        var availability = new Dictionary<string, bool>();

        if (email != null)
        {
            availability["Email"] = !query.Any(u => u.Email == email);
        }

        if (username != null)
        {
            availability["Username"] = !query.Any(u => u.Username == username);
        }
        
        return availability;
    }
}