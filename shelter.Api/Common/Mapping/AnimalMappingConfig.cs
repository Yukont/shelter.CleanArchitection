using Mapster;
using shelter.Application.Animals.Commands.CreateAnimal;
using shelter.Contracts.Animals;
using shelter.Domain.Animal;
using shelter.Domain.Animal.Entities;

namespace shelter.Api.Common.Mapping;

public class AnimalMappingConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<CreateAnimalsRequest, CreateAnimalCommand>();
        /*.Map(dest => dest.SpeciesId, src => src.SpeciesId)
        .Map(dest => dest.GenderId, src => src.GenderId)
        .Map(dest => dest.SterilizedId, src => src.SterilizedId)
        .Map(dest => dest.AdoptionStatusId, src => src.AdoptionStatusId)
        .Map(dest => dest.HealthStatusId, src => src.HealthStatusId)
        .Map(dest => dest, src => src.Request*/

        config.NewConfig<Animal, AnimalResponce>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.SpeciesId, src => src.SpeciesId.Value)
            .Map(dest => dest.GenderId, src => src.GenderId.Value)
            .Map(dest => dest.HealthStatusId, src => src.HealthStatusId.Value)
            .Map(dest => dest.SterilizedId, src => src.SterilizedId.Value)
            .Map(dest => dest.AdoptionStatusId, src => src.AdoptionStatusId.Value);

        config.NewConfig<Vaccination, VaccinationResponce>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
