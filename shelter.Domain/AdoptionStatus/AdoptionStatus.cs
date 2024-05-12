using shelter.Domain.AdoptionStatus.ValueObjects;
using shelter.Domain.Common.Models;

namespace shelter.Domain.AdoptionStatus;

public sealed class AdoptionStatus : AggregateRoot<AdoptionStatusId>
{
    public string Name { get; }
    private AdoptionStatus(AdoptionStatusId id, string name)
        : base(id)
    {
        Name = name;
    }

    public static AdoptionStatus Create(string name)
    {
        return new(AdoptionStatusId.CreateUnique(), name);
    }
#pragma warning disable CS8618
    private AdoptionStatus()
    {

    }
#pragma warning restore CS8618 
}
