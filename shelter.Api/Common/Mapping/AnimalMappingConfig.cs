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
        config.NewConfig<(
            CreateAnimalsRequest Request,
            string SpeciesId, 
            string GenderId, 
            string SterilizedId, 
            string AdoptionStatusId, 
            string HealthStatusId), 
            CreateAnimalCommand>()
            .Map(dest => dest.SpeciesId, src => src.SpeciesId)
            .Map(dest => dest.GenderId, src => src.GenderId)
            .Map(dest => dest.SterilizedId, src => src.SterilizedId)
            .Map(dest => dest.AdoptionStatusId, src => src.AdoptionStatusId)
            .Map(dest => dest.HealthStatusId, src => src.HealthStatusId)
            .Map(dest => dest, src => src.Request);

        config.NewConfig<Animal, AnimalResponce>()
            .Map(dest => dest.Id, src => src.Id.Value);

        config.NewConfig<Vaccination, VaccinationResponce>()
            .Map(dest => dest.Id, src => src.Id.Value);
    }
}
