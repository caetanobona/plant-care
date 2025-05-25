using System.ComponentModel.DataAnnotations;

namespace PlantCare.Domain.Entities;

public abstract class BaseEntity
{
    [Required]
    public virtual long Id { get; set; }
    
    [Required]
    public bool Active { get; set; }
    
    [Required]
    public DateTime CreatedAt { get; set; }

    [Required]
    public DateTime UpdatedAt { get; set; }
}