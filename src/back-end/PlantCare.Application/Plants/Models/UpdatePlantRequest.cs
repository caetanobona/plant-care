namespace PlantCare.Application.Plants.Models;

public class UpdatePlantRequest
{
    public long Id { get; set; }
    public long? UserId { get; set; }
    public string? Name { get; set; }
    public string? Species { get; set; }
    public string? ImageHash { get; set; }
    public TimeSpan? WateringInterval { get; set; }
    public DateTime? LastWatered { get; set; }
    public string? LightRequirements { get; set; }
}