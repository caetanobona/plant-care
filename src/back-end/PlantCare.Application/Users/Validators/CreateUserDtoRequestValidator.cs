using FluentValidation;
using PlantCare.Application.DTOs;

namespace PlantCare.Application.Users.Validators;

public class CreateUserDtoRequestValidator : AbstractValidator<CreateUserDtoRequest>
{
    public CreateUserDtoRequestValidator()
    {
        RuleFor(x => x.Username)
            .NotEmpty().WithMessage("Username is required")
            .MinimumLength(3).WithMessage("Must be at least 3 characters")
            .MaximumLength(50).WithMessage("Username exceeds 50 characters");
        
        RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Name is required")
            .MinimumLength(3).WithMessage("Must be at least 3 characters")
            .MaximumLength(100).WithMessage("Name exceeds 100 characters");
        
        RuleFor(x => x.Email)
            .NotEmpty().WithMessage("Email is required")
            .EmailAddress().WithMessage("Must be a valid email address")
            .MaximumLength(320).WithMessage("Email exceeds 320 characters");

        RuleFor(x => x.Password)
            .NotEmpty().WithMessage("Password is required")
            .MinimumLength(3).WithMessage("Must be at least 8 characters")
            .MaximumLength(50).WithMessage("Password exceeds 50 characters");
    }
}