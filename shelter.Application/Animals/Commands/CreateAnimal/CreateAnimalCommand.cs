using ErrorOr;
using MediatR;
using shelter.Domain.Animal;

namespace shelter.Application.Animals.Commands.CreateAnimal;

public record CreateAnimalCommand(
    string Name,
    int Age,
    string Description,
    string Photo,
    string SpeciesId,
    string GenderId,
    string SterilizedId,
    string AdoptionStatusId,
    string HealthStatusId,
    List<VaccinationCommand> Vaccinations) : IRequest<ErrorOr<Animal>>;

public record VaccinationCommand(
    string Name,
    DateTime DateTime);
