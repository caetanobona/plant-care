using System.Collections.Generic;
using FluentValidation;
using PlantCare.Domain.Entities;

namespace PlantCare.Domain.Services;

public interface IBaseService<TEntity> where TEntity : BaseEntity
{
    TEntity Add<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;

    void Delete(long id);
    
    IList<TEntity> GetAll();
    
    TEntity GetById(long id);
    
    TEntity Update<TValidator>(TEntity obj) where TValidator : AbstractValidator<TEntity>;
}