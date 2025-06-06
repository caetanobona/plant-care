using System.ComponentModel.DataAnnotations;

namespace PlantCare.Application.Users.DTOs;

public class UserDto
{
    public required string Email { get; set; }

    public required string Name { get; set; }

    public required string Username { get; set; }
    
}