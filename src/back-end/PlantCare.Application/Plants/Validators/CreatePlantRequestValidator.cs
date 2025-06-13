using FluentValidation;
using FluentValidation.Validators;
using PlantCare.Application.Plants.Models;

namespace PlantCare.Application.Plants.Validators;

public class CreatePlantRequestValidator : AbstractValidator<CreatePlantRequest>
{
    public CreatePlantRequestValidator()
    {
        RuleFor(request => request.UserId)
            .NotNull().WithMessage("Plant must have an owner")
            .GreaterThan(0).WithMessage("User id must be a valid ID");
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(3).WithMessage("Name must be at least 3 characters")
            .MaximumLength(50).WithMessage("Name cannot exceed 50 characters");
        RuleFor(x => x.Species)
            .NotEmpty().WithMessage("Species is required")
            .MinimumLength(10).WithMessage("Species must be at least 10 characters")
            .MaximumLength(120).WithMessage("Species cannot exceed 100 characters");
        RuleFor(x => x.WateringInterval)
            .NotNull().WithMessage("Plant must have a watering interval");
        RuleFor(x => x.LightRequirements)
            .MaximumLength(50).WithMessage("LightRequirements cannot exceed 50 characters");
    }
    
}