using shelter.Domain.Animal.ValueObjects;
using shelter.Domain.Common.Models;

namespace shelter.Domain.Animal.Entities;

public sealed class HealthStatus : Entity<HealthStatusId>
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
