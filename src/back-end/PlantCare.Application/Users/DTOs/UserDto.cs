using System.ComponentModel.DataAnnotations;

namespace PlantCare.Application.DTOs;

public class UserDto
{
    public string Email { get; set; }

    public string Name { get; set; }

    public string Username { get; set; }
    
}