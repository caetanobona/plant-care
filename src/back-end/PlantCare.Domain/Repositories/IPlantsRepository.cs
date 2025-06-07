using PlantCare.Domain.Entities;

namespace PlantCare.Domain.Repositories;

public interface IPlantsRepository : IBaseRepository<Plant>
{
    Task<List<Plant>> GetAllByUserAsync(long userId);
}