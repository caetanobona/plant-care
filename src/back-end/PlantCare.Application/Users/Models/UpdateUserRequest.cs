namespace PlantCare.Application.Users.Models;

public class UpdateUserRequest
{
    public required long Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Name { get; set; }
    public string? Password { get; set; }
}