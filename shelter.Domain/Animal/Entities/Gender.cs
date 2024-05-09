using shelter.Domain.Animal.ValueObjects;
using shelter.Domain.Common.Models;

namespace shelter.Domain.Animal.Entities;

public sealed class Gender : Entity<GenderId>
{
    public string Name { get; }
    private Gender(GenderId id, string name)
        : base(id)
    {
        Name = name;
    }

    public static Gender Create(string name)
    {
        return new(GenderId.CreateUnique(), name);
    }
}
