using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlantCare.Domain.Entities;

public class User :  BaseEntity
{
    public required string Email { get; set; }
    public required string Name { get; set; }
    public required string Username { get; set; }
    public required string PasswordHash { get; set; }
    public virtual ICollection<Plant> Plants { get; set; } = new List<Plant>();
}