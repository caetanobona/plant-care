using System.ComponentModel.DataAnnotations;

namespace PlantCare.Domain.Entities;

public abstract class BaseEntity
{
    public virtual long Id { get; set; }
    public bool Active { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}