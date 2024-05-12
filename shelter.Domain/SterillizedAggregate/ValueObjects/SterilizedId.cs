using shelter.Domain.Common.Models;

namespace shelter.Domain.SterillizedAggregate.ValueObjects;

public sealed class SterilizedId : ValueObject
{
    public Guid Value { get; }

    private SterilizedId(Guid value)
    {
        Value = value;
    }

    public static SterilizedId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static SterilizedId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
