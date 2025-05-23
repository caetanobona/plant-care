using System.ComponentModel.DataAnnotations;

namespace PlantCare.Application.DTOs;

public class CreateUserRequest
{
    [Required]
    public required string Username { get; set; }
    [Required]
    public required string Email { get; set; }
    [Required]
    public required string Name { get; set; }
    [Required]
    public required string Password { get; set; }
}