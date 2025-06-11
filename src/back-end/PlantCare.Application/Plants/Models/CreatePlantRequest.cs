namespace PlantCare.Application.Plants.Models;

public class CreatePlantRequest
{
    public required long UserId { get; set; }
    public required string Name { get; set; }
    public required string Species { get; set; }
    public string? ImageHash { get; set; }
    public required TimeSpan WateringInterval { get; set; }
    public DateTime? LastWatered { get; set; }
    public string? LightRequirements { get; set; }
}