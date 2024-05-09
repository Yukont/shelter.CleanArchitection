using shelter.Domain.Animal.ValueObjects;
using shelter.Domain.Common.Models;

namespace shelter.Domain.Animal.Entities;

public sealed class Sterilized : Entity<SterilizedId>
{
    public string Name { get; }
    private Sterilized(SterilizedId id, string name)
        : base(id)
    {
        Name = name;
    }

    public static Sterilized Create(string name)
    {
        return new(SterilizedId.CreateUnique(), name);
    }
}
