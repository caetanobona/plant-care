using System.ComponentModel.DataAnnotations;

namespace PlantCare.Domain.Entities;

public class Plant : BaseEntity
{
    [Required]
    public User User { get; set; }
    [Required]
    [MaxLength(50)]
    public string Name { get; set; }
    [Required]
    [MaxLength(120)]
    public string Species { get; set; }
    [Required]
    public bool Active { get; set; }
    [Required]
    [MaxLength(255)]
    public string? ImageUrl { get; set; }
    [Required]
    public TimeSpan WateringInterval { get; set; }
    public DateTime? LastWatered { get; set; }
    [MaxLength(50)]
    public string? LightRequirements { get; set; }
}