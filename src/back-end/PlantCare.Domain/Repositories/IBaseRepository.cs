using System.Collections.Generic;
using System.Threading.Tasks;
using PlantCare.Domain.Entities;

namespace PlantCare.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task<User?> InsertAsync(TEntity obj);
    Task<User?> UpdateAsync(TEntity obj);
    Task<bool> DeleteAsync(long id);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity?> GetByIdAsync(long id);
    Task<bool> ExistsAsync(long id);
}