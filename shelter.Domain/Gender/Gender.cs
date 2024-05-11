using shelter.Domain.Common.Models;
using shelter.Domain.Gender.ValueObjects;

namespace shelter.Domain.Gender;

public sealed class Gender : AggregateRoot<GenderId>
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
