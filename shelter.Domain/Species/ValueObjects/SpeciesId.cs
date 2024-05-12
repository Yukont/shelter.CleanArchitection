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
    public static SpeciesId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
