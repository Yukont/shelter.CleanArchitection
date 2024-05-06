using FluentValidation;
using shelter.Application;

namespace shelter.Application.Authentication.Commands.Register;

public class RegisterCommandValidator : AbstractValidator<RegisterCommand>
{
    public RegisterCommandValidator()
    {
        RuleFor(x => x.FirstName).NotEmpty();
        RuleFor(x => x.LastName).NotEmpty();
        RuleFor(x => x.Email).NotEmpty();
        RuleFor(x => x.Phone).NotEmpty();
        RuleFor(x => x.IdUserRole).NotEmpty();
        RuleFor(x => x.Password).NotEmpty();
    }
}
