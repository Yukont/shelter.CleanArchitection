using shelter.Domain.AdoptionApplicationStatus.ValueObjects;
using shelter.Domain.Common.Models;

namespace shelter.Domain.AdoptionApplicationStatus;

public sealed class AdoptionApplicationStatus : AggregateRoot<AdoptionApplicationStatusId>
{
    public string Name { get; }
    private AdoptionApplicationStatus(AdoptionApplicationStatusId id, string name)
        : base(id)
    {
        Name = name;
    }

    public static AdoptionApplicationStatus Create(string name)
    {
        return new(AdoptionApplicationStatusId.CreateUnique(), name);
    }
#pragma warning disable CS8618
    private AdoptionApplicationStatus()
    {

    }
#pragma warning restore CS8618 
}
