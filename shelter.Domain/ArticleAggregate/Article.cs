using shelter.Domain.ArticleAggregate.ValueObjects;
using shelter.Domain.Common.Models;

namespace shelter.Domain.ArticleAggregate;

public sealed class Article : AggregateRoot<ArticleId>
{
    public string Heading { get; }
    public string Description { get; }
    public DateTime DateTime { get; }
    private Article(ArticleId id, string heading, string description, DateTime dateTime)
        : base(id)
    {
        Heading = heading;
        Description = description;
        DateTime = dateTime;
    }

    public static Article Create(string heading, string description)
    {
        return new(ArticleId.CreateUnique(), heading, description, DateTime.UtcNow);
    }
#pragma warning disable CS8618
    private Article()
    {

    }
#pragma warning restore CS8618 
}
