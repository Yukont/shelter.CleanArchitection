using shelter.Domain.Common.Models;

namespace shelter.Domain.AdoptionStatusAggregate.ValueObjects;

public sealed class AdoptionStatusId : ValueObject
{
    public Guid Value { get; }

    private AdoptionStatusId(Guid value)
    {
        Value = value;
    }

    public static AdoptionStatusId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public static AdoptionStatusId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
