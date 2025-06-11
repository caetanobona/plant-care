using FluentValidation;
using PlantCare.Application.Plants.Models;

namespace PlantCare.Application.Plants.Validators;

public class UpdatePlantRequestValidator : AbstractValidator<UpdatePlantRequest>
{
    public UpdatePlantRequestValidator()
    {
        RuleFor(x => x.Id)
            .NotEmpty().WithMessage("Id is required")
            .GreaterThan(0).WithMessage("Plant id must be a valid ID");
        RuleFor(x => x.UserId)
            .GreaterThan(0).WithMessage("User id must be a valid ID");
        RuleFor(x => x.Name)
            .MinimumLength(3).WithMessage("Name must be at least 3 characters")
            .MaximumLength(50).WithMessage("Name cannot exceed 50 characters");
        RuleFor(x => x.Species)
            .MinimumLength(10).WithMessage("Species must be at least 10 characters")
            .MaximumLength(120).WithMessage("Species cannot exceed 100 characters");
        RuleFor(x => x.ImageHash)
            .MaximumLength(64).WithMessage("ImageHash cannot exceed 64 characters");
        RuleFor(x => x.LightRequirements)
            .MaximumLength(50).WithMessage("LightRequirements cannot exceed 50 characters");
    }
}