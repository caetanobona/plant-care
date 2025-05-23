using System;
using System.Collections.Generic;

namespace PlantCare.Infra.Persistence.Entities;

public partial class PlantEntity
{
    public long Id { get; set; }

    public long UserId { get; set; }

    public string Name { get; set; } = null!;

    public string Species { get; set; } = null!;

    public bool Active { get; set; }

    public string? ImageUrl { get; set; }

    public TimeSpan WateringInterval { get; set; }

    public DateTime? LastWatered { get; set; }

    public string? LightRequirements { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual UserEntity UserEntity { get; set; } = null!;
}
