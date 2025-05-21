using System.Collections.Generic;
using System.Threading.Tasks;
using PlantCare.Domain.Entities;

namespace PlantCare.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    Task InsertAsync(TEntity obj);
    Task UpdateAsync(TEntity obj);
    Task DeleteAsync(long id);
    Task<List<TEntity>> GetAllAsync();
    Task<TEntity> GetByIdAsync(long id);
}