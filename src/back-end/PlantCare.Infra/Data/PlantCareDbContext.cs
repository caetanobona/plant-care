using Microsoft.EntityFrameworkCore;
using PlantCare.Domain.Entities;
using PlantCare.Infra.Configurations;

namespace PlantCare.Infra.Data;

public class PlantCareDbContext(DbContextOptions<PlantCareDbContext> options) : DbContext(options)
{
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new UsersConfiguration());
        modelBuilder.ApplyConfiguration(new PlantsConfiguration());
        
        base.OnModelCreating(modelBuilder);
    }
}