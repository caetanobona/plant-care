using Microsoft.EntityFrameworkCore;
using PlantCare.Domain.Entities;
using PlantCare.Domain.Repositories;
using PlantCare.Infra.Data;

namespace PlantCare.Infra.Repositories;

public class PlantsRepository : BaseRepository<Plant>, IPlantsRepository
{
    public PlantsRepository(PlantCareDbContext dbContext) : base(dbContext) { }

    public async Task<List<Plant>> GetAllByUserAsync(User user)
    {
        var plants = await DbSet.Where(p => p.UserId == user.Id).ToListAsync();
        
        return plants;
    }

    public async Task<Plant?> GetBySpeciesAsync(string species)
    {
        var plant = await DbSet.FirstOrDefaultAsync(x => x.Species == species);

        return plant;
    }
}