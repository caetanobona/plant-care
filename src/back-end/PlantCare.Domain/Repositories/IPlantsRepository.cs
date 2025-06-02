using PlantCare.Domain.Entities;

namespace PlantCare.Domain.Repositories;

public interface IPlantsRepository : IBaseRepository<Plant>
{
    Task<Plant?> GetBySpeciesAsync(string species);
}