using shelter.Domain.Animal.Entities;
using shelter.Domain.Animal.ValueObjects;
using shelter.Domain.Common.Models;

namespace shelter.Domain.Animal;

public sealed class Animal : AggregateRoot<AnimalId>
{
    public string Name { get; }
    public int Age { get; }
    public string Description { get; }
    public string Photo { get; }
    private readonly List<Vaccination> _vaccinations = new();
    public IReadOnlyList<Vaccination> Vaccinations => _vaccinations.AsReadOnly();
    public SpeciesId SpeciesId { get; }
    public GenderId GenderId { get; }
    public SterilizedId SterilizedId { get; }
    public AdoptionStatusId AdoptionStatusId { get; }
    public HealthStatusId HealthStatusId { get; }

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
        HealthStatusId healthStatusId)
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
        HealthStatusId healthStatusId)
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
            healthStatusId);
    }
}
