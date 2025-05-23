using FluentValidation;
using PlantCare.Domain.Entities;

namespace PlantCare.Domain.Services;

public interface IBaseService<TEntity> where TEntity : BaseEntity
{
    TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

    void Delete(int id);
    
    IList<TEntity> Get();
    
    TEntity GetByID(int id);
    
    TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
}