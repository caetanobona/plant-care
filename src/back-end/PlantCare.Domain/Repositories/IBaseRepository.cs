using System.Collections.Generic;
using System.Threading.Tasks;
using PlantCare.Domain.Entities;

namespace PlantCare.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<TEntity?> InsertAsync(TEntity obj);
    Task<TEntity?> UpdateAsync(TEntity obj);
    Task DeleteAsync(TEntity obj);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(long id);
    Task<bool> ExistsAsync(long id);
}