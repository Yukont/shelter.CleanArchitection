using shelter.Domain.Animal.ValueObjects;
using shelter.Domain.Common.Models;

namespace shelter.Domain.Animal.Entities;

public sealed class AdoptionStatus : Entity<AdoptionStatusId>
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
}
