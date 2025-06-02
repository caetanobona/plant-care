namespace PlantCare.Application.Plants.Models;

public class CreatePlantRequest
{
    public required string UserId { get; set; }
    public required string Name { get; set; }
    public required string Species { get; set; }
    public string? ImageUrl { get; set; }
    public required TimeSpan WateringInterval { get; set; }
    public string? LightRequirements { get; set; }
}