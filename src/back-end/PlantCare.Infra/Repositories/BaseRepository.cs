using Microsoft.EntityFrameworkCore;
using PlantCare.Domain.Entities;
using PlantCare.Domain.Repositories;
using PlantCare.Infra.Data;
using PlantCare.Infra.Exceptions;

namespace PlantCare.Infra.Repositories;

public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity: BaseEntity
{
    protected readonly PlantCareDbContext DbContext;
    protected readonly DbSet<TEntity> DbSet;
    
    protected BaseRepository( PlantCareDbContext context )
    {
        DbContext = context;
        DbSet = DbContext.Set<TEntity>();
    }
    
    public async Task<TEntity?> InsertAsync(TEntity obj)
    {
        var addedEntity = await DbSet.AddAsync(obj);
        await DbContext.SaveChangesAsync();
        
        return addedEntity.Entity;
    }

    public async Task<TEntity?> UpdateAsync(TEntity obj)
    {
        var updatedEntity = DbSet.Update(obj);
        
        await DbContext.SaveChangesAsync();
        
        return updatedEntity.Entity;
    }
    
    public async Task DeleteAsync(TEntity obj)
    {
        obj.Active = false;
        DbSet.Update(obj);
        await DbContext.SaveChangesAsync();
    }

    public async Task<List<TEntity>> GetAllAsync()
    {
        var entities = await DbSet.ToListAsync();
        
        return entities;
    }

    public async Task<TEntity?> GetByIdAsync(long id)
    {
        var entity = await DbSet.FindAsync(id);
        
        return entity;
    }
    
    public async Task<bool> ExistsAsync(long id)
    {
        var entity = await DbSet.FindAsync(id);
        
        return entity != null;
    }
}