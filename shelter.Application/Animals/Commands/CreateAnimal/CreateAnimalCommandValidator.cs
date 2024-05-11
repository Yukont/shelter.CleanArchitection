using FluentValidation;

namespace shelter.Application.Animals.Commands.CreateAnimal;

public class CreateAnimalCommandValidator : AbstractValidator<CreateAnimalCommand>
{
    public CreateAnimalCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();
    }
}
