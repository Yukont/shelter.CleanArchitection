using shelter.Domain.Common.Models;

namespace shelter.Domain.Gender.ValueObjects;

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
    public static GenderId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
