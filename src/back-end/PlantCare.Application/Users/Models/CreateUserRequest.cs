using System.ComponentModel.DataAnnotations;

namespace PlantCare.Application.DTOs;

public class CreateUserRequest
{
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
    public required string Password { get; set; }
}