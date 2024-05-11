using shelter.Domain.Common.Models;
using shelter.Domain.Species.ValueObjects;

namespace shelter.Domain.Species;

public sealed class Species : AggregateRoot<SpeciesId>
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
