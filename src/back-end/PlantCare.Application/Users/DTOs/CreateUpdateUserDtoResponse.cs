namespace PlantCare.Application.Users.DTOs;

public class CreateUpdateUserDtoResponse
{
    public required long Id { get; set; }
    public required string Username { get; set; }
    public required string Email { get; set; }
    public required string Name { get; set; }
}