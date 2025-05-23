using System;
using System.Collections.Generic;

namespace PlantCare.Infra.Persistence.Entities;

public partial class UserEntity
{
    public long Id { get; set; }

    public string Email { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Username { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public bool Active { get; set; }

    public DateTime CreatedAt { get; set; }

    public DateTime UpdatedAt { get; set; }

    public virtual ICollection<PlantEntity> Plants { get; set; } = new List<PlantEntity>();
}
