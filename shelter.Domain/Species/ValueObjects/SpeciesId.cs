using shelter.Domain.Common.Models;

namespace shelter.Domain.Species.ValueObjects;

public sealed class SpeciesId : ValueObject
{
    public Guid Value { get; }

    private SpeciesId(Guid value)
    {
        Value = value;
    }

    public static SpeciesId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
