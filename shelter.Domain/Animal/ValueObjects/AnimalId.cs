using shelter.Domain.Common.Models;

namespace shelter.Domain.Animal.ValueObjects;

public sealed class AnimalId : ValueObject
{
    public Guid Value { get; }

    private AnimalId(Guid value)
    {
        Value = value;
    }

    public static AnimalId CreateUnique()
    {
        return new (Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
