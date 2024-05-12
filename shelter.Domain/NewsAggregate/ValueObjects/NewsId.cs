using shelter.Domain.Common.Models;

namespace shelter.Domain.NewsAggregate.ValueObjects;

public sealed class NewsId : ValueObject
{
    public Guid Value { get; }

    private NewsId(Guid value)
    {
        Value = value;
    }

    public static NewsId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
