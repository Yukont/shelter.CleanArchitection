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

    public static AnimalId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
