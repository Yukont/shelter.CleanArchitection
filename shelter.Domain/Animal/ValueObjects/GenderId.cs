using shelter.Domain.Common.Models;

namespace shelter.Domain.Animal.ValueObjects;

public sealed class GenderId : ValueObject
{
    public Guid Value { get; }

    private GenderId(Guid value)
    {
        Value = value;
    }

    public static GenderId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
