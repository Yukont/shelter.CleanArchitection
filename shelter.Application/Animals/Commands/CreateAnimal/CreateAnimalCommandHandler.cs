using ErrorOr;
using MediatR;
using shelter.Application.Common.Interfaces.Persistence;
using shelter.Domain.AdoptionStatus.ValueObjects;
using shelter.Domain.Animal;
using shelter.Domain.Animal.Entities;
using shelter.Domain.Gender.ValueObjects;
using shelter.Domain.HealthStatus.ValueObjects;
using shelter.Domain.Species.ValueObjects;
using shelter.Domain.Sterellized.ValueObjects;

namespace shelter.Application.Animals.Commands.CreateAnimal;

public class CreateAnimalCommandHandler : IRequestHandler<CreateAnimalCommand, ErrorOr<Animal>>
{
    private readonly IAnimalRepository _animalRepository;

    public CreateAnimalCommandHandler(IAnimalRepository animalRepository)
    {
        _animalRepository = animalRepository;
    }

    public async Task<ErrorOr<Animal>> Handle(CreateAnimalCommand request, CancellationToken cancellationToken)
    {
        var animal = Animal.Create(
            request.Name,
            request.Age,
            request.Description,
            request.Photo,
            SpeciesId.CreateUnique(),//request.SpeciesId,
            GenderId.CreateUnique(),//request.GenderId,
            SterilizedId.CreateUnique(),//request.SterilizedId,
            AdoptionStatusId.CreateUnique(),//request.AdoptionStatusId,
            HealthStatusId.CreateUnique(),//request.HealthStatusId,
            request.Vaccinations.ConvertAll(vaccination => Vaccination.Create(
                vaccination.Name,
                vaccination.DateTime)));

        _animalRepository.Add(animal);

        return animal;
    }
}
