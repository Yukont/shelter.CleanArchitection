using shelter.Domain.AdoptionStatusAggregate.ValueObjects;
using shelter.Domain.AnimalAggregate.Entities;
using shelter.Domain.AnimalAggregate.ValueObjects;
using shelter.Domain.Common.Models;
using shelter.Domain.GenderAggregate.ValueObjects;
using shelter.Domain.HealthStatusAggregate.ValueObjects;
using shelter.Domain.SpeciesAggregate.ValueObjects;
using shelter.Domain.SterillizedAggregate.ValueObjects;

namespace shelter.Domain.AnimalAggregate;

public sealed class Animal : AggregateRoot<AnimalId>
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Description { get; private set; }
    public string Photo { get; private set; }
    public DateTime DateTime { get; private set; }
    private readonly List<Vaccination> _vaccinations = new();
    public IReadOnlyList<Vaccination> Vaccinations => _vaccinations.AsReadOnly();
    public SpeciesId SpeciesId { get; private set; }
    public GenderId GenderId { get; private set; }
    public SterilizedId SterilizedId { get; private set; }
    public AdoptionStatusId AdoptionStatusId { get; private set; }
    public HealthStatusId HealthStatusId { get; private set; }

    private Animal(
        AnimalId id,
        string name,
        int age,
        string description,
        string photo,
        SpeciesId speciesId,
        GenderId genderId,
        SterilizedId sterilizedId,
        AdoptionStatusId adoptionStatusId,
        HealthStatusId healthStatusId,
        List<Vaccination> vaccinations)
        : base(id)
    {
        Name = name;
        Age = age;
        Description = description;
        Photo = photo;
        SpeciesId = speciesId;
        GenderId = genderId;
        SterilizedId = sterilizedId;
        AdoptionStatusId = adoptionStatusId;
        HealthStatusId = healthStatusId;
        _vaccinations = vaccinations;
    }

    public static Animal Create(
        string name,
        int age,
        string description,
        string photo,
        SpeciesId speciesId,
        GenderId genderId,
        SterilizedId sterilizedId,
        AdoptionStatusId adoptionStatusId,
        HealthStatusId healthStatusId,
        List<Vaccination> vaccinations)
    {
        return new(
            AnimalId.CreateUnique(),
            name,
            age,
            description,
            photo,
            speciesId,
            genderId,
            sterilizedId,
            adoptionStatusId,
            healthStatusId,
            vaccinations);
    }

#pragma warning disable CS8618
    private Animal()
    {

    }
#pragma warning restore CS8618 
}
