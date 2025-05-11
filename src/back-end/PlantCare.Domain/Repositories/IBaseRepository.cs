using PlantCare.Domain.Entities;

namespace PlantCare.Domain.Repositories;

public interface IBaseRepository<TEntity> where TEntity : BaseEntity
{
    void Insert(TEntity obj);
    void Update(TEntity obj);
    void Delete(int id);
    List<TEntity> Get();
    TEntity GetById(int id);
}