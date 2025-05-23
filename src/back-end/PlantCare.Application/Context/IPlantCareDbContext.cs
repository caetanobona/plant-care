using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using PlantCare.Domain.Entities;

namespace PlantCare.Application.Context;

public interface IPlantCareDbContext
{
    DbSet<User> Users { get; set; }
    
    DbSet<Plant> Plants { get; set; }
    
    DatabaseFacade Database { get; }
    
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}