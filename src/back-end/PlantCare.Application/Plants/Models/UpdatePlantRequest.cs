namespace PlantCare.Application.Plants.Models;

public class UpdatePlantRequest
{
    public string? UserId { get; set; }
    public string? Name { get; set; }
    public string? Species { get; set; }
    public string? ImageUrl { get; set; }
    public TimeSpan? WateringInterval { get; set; }
    public string? LightRequirements { get; set; }
}