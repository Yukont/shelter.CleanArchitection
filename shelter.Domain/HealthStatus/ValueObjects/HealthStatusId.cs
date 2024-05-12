using shelter.Domain.Common.Models;

namespace shelter.Domain.HealthStatus.ValueObjects;

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
    public static HealthStatusId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
