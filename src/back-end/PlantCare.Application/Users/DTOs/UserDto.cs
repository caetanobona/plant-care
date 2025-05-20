using System.ComponentModel.DataAnnotations;

namespace PlantCare.Application.DTOs;

public class UserDto
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
    public bool Active { get; set; }
}