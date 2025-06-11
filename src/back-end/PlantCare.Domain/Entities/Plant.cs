using System;
using System.ComponentModel.DataAnnotations;

namespace PlantCare.Domain.Entities;

public class Plant : BaseEntity
{
    public long UserId { get; set; }
    public required string Name { get; set; }
    public required string Species { get; set; }
    public string? ImageHash { get; set; }
    public TimeSpan WateringInterval { get; set; }
    public DateTime? LastWatered { get; set; }
    public string? LightRequirements { get; set; }
    public virtual User User { get; set; } = null!;
}