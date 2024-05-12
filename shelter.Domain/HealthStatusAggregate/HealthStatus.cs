using shelter.Domain.Common.Models;
using shelter.Domain.HealthStatusAggregate.ValueObjects;

namespace shelter.Domain.HealthStatusAggregate;

public sealed class HealthStatus : AggregateRoot<HealthStatusId>
{
    public string Name { get; }
    private HealthStatus(HealthStatusId id, string name)
        : base(id)
    {
        Name = name;
    }

    public static HealthStatus Create(string name)
    {
        return new(HealthStatusId.CreateUnique(), name);
    }
#pragma warning disable CS8618
    private HealthStatus()
    {

    }
#pragma warning restore CS8618 
}
