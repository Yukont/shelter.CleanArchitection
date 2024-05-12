using ErrorOr;
using MediatR;
using shelter.Domain.AnimalAggregate;

namespace shelter.Application.Animals.Commands.CreateAnimal;

public record CreateAnimalCommand(
    string Name,
    int Age,
    string Description,
    string Photo,
    Guid SpeciesId,
    Guid GenderId,
    Guid SterilizedId,
    Guid AdoptionStatusId,
    Guid HealthStatusId,
    List<VaccinationCommand> Vaccinations) : IRequest<ErrorOr<Animal>>;

public record VaccinationCommand(
    string Name,
    DateTime DateTime);
