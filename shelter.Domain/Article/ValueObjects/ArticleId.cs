using shelter.Domain.Common.Models;

namespace shelter.Domain.Article.ValueObjects;

public sealed class ArticleId : ValueObject
{
    public Guid Value { get; }

    private ArticleId(Guid value)
    {
        Value = value;
    }

    public static ArticleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
