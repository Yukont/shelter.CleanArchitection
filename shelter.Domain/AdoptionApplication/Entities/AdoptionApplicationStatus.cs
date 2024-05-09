using shelter.Domain.AdoptionApplication.ValueObjects;
using shelter.Domain.Common.Models;

namespace shelter.Domain.AdoptionApplication.Entities;

public sealed class AdoptionApplicationStatus : Entity<AdoptionApplicationStatusId>
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
}
