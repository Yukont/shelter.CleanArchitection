using shelter.Domain.Common.Models;
using shelter.Domain.News.ValueObjects;

namespace shelter.Domain.News;

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
}
