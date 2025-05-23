using System.ComponentModel.DataAnnotations;

namespace PlantCare.Domain.Entities;

public class User :  BaseEntity
{
    [Required]
    [MaxLength(320)]
    public string Email { get; set; }
    [Required]
    [MaxLength(100)]
    public string Name { get; set; }
    [Required]
    [MaxLength(50)]
    public string Username { get; set; }
    [Required]
    [MaxLength(255)]
    public string PasswordHash { get; set; }
    [Required]
    public bool Active { get; set; }
    [Required]
    public DateTime CreatedAt { get; set; }
    [Required]
    public DateTime UpdatedAt { get; set; }
}