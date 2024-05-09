using shelter.Domain.Common.Models;

namespace shelter.Domain.Animal.ValueObjects;

public sealed class HealthStatusId : ValueObject
{
    public Guid Value { get; }

    private HealthStatusId(Guid value)
    {
        Value = value;
    }

    public static HealthStatusId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
