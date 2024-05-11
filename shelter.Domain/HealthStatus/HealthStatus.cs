using shelter.Domain.Common.Models;
using shelter.Domain.HealthStatus.ValueObjects;

namespace shelter.Domain.HealthStatus;

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
}
