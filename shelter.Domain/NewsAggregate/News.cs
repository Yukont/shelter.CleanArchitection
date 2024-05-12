using shelter.Domain.Common.Models;
using shelter.Domain.NewsAggregate.ValueObjects;

namespace shelter.Domain.NewsAggregate;

public sealed class News : AggregateRoot<NewsId>
{
    public string Heading { get; }
    public string Description { get; }
    public DateTime DateTime { get; }
    private News(NewsId id, string heading, string description, DateTime dateTime)
        : base(id)
    {
        Heading = heading;
        Description = description;
        DateTime = dateTime;
    }

    public static News Create(string heading, string description)
    {
        return new(NewsId.CreateUnique(), heading, description, DateTime.UtcNow);
    }
#pragma warning disable CS8618
    private News()
    {

    }
#pragma warning restore CS8618 
}
