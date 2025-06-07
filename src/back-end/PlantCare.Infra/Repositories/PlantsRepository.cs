using Microsoft.EntityFrameworkCore;
using PlantCare.Domain.Entities;
using PlantCare.Domain.Repositories;
using PlantCare.Infra.Data;

namespace PlantCare.Infra.Repositories;

public class PlantsRepository : BaseRepository<Plant>, IPlantsRepository
{
    public PlantsRepository(PlantCareDbContext dbContext) : base(dbContext) { }

    public async Task<List<Plant>> GetAllByUserAsync(long userId)
    {
        var plants = await DbSet.Where(p => p.UserId == userId).ToListAsync();
        
        return plants;
    }
    
}