using shelter.Domain.Common.Models;
using shelter.Domain.Sterellized.ValueObjects;

namespace shelter.Domain.Sterellized;

public sealed class Sterilized : AggregateRoot<SterilizedId>
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
#pragma warning disable CS8618
    private Sterilized()
    {

    }
#pragma warning restore CS8618 
}
