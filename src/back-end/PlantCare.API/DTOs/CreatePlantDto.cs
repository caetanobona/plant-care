namespace PlantCare.API.DTOs;

public class CreatePlantDto
{
    public required long UserId { get; set; }
    public required string Name { get; set; }
    public required string Species { get; set; }
    public IFormFile? Image { get; set; }
    public required TimeSpan WateringInterval { get; set; }
    public DateTime? LastWatered { get; set; }
    public string? LightRequirements { get; set; }
}