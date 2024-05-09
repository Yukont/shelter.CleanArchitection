using shelter.Domain.Animal.ValueObjects;
using shelter.Domain.Common.Models;

namespace shelter.Domain.Animal.Entities;

public sealed class Species : Entity<SpeciesId>
{
    public string Name { get; }
    private Species(SpeciesId id, string name)
        : base(id)
    {
        Name = name;
    }

    public static Species Create(string name)
    {
        return new(SpeciesId.CreateUnique(), name);
    }
}
