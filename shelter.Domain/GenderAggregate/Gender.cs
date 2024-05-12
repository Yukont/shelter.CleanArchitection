using shelter.Domain.Common.Models;
using shelter.Domain.GenderAggregate.ValueObjects;

namespace shelter.Domain.GenderAggregate;

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
#pragma warning disable CS8618
    private Gender()
    {

    }
#pragma warning restore CS8618 
}
