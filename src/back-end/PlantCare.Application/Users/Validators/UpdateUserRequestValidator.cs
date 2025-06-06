using FluentValidation;
using PlantCare.Application.Users.Models;

namespace PlantCare.Application.Users.Validators;

public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
{
    public UpdateUserRequestValidator()
    {
        RuleFor(x => x.Username)
            .MinimumLength(3).WithMessage("Must be at least 3 characters")
            .MaximumLength(50).WithMessage("Username exceeds 50 characters");
        
        RuleFor(x => x.Name)
            .MinimumLength(3).WithMessage("Must be at least 3 characters")
            .MaximumLength(100).WithMessage("Name exceeds 100 characters");
        
        RuleFor(x => x.Email)
            .EmailAddress().WithMessage("Must be a valid email address")
            .MaximumLength(320).WithMessage("Email exceeds 320 characters");

        RuleFor(x => x.Password)
            .MinimumLength(8).WithMessage("Must be at least 8 characters")
            .MaximumLength(50).WithMessage("Password exceeds 50 characters");
    }
}