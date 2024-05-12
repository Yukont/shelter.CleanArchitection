using shelter.Domain.Common.Models;

namespace shelter.Domain.AdoptionApplicationAggregate.ValueObjects;

public sealed class AdoptionApplicationId : ValueObject
{
    public Guid Value { get; }

    private AdoptionApplicationId(Guid value)
    {
        Value = value;
    }

    public static AdoptionApplicationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
