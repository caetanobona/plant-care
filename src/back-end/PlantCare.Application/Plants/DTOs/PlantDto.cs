namespace PlantCare.Application.Plants.DTOs;

public class PlantDto
{
    public required string Name { get; set; }
    public required string Species  { get; set; }
    public string? ImageUrl { get; set; }
    public TimeSpan WateringInterval { get; set; }
    public DateTime? LastWatered { get; set; }
    public string? LightRequirements { get; set; }
}