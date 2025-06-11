namespace PlantCare.Application.Plants.DTOs;

public class CreateUpdatePlantResponse
{
    public required string Name { get; set; }
    public required string Species  { get; set; }
    public string? ImageHash { get; set; }
    public TimeSpan WateringInterval { get; set; }
    public DateTime? LastWatered { get; set; }
    public string? LightRequirements { get; set; }
}