using shelter.Domain.Common.Models;

namespace shelter.Domain.Animal.ValueObjects;

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

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
