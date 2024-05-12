using shelter.Domain.AnimalAggregate.ValueObjects;
using shelter.Domain.Common.Models;

namespace shelter.Domain.AnimalAggregate.Entities;

public sealed class Vaccination : Entity<VaccinationId>
{
    public string Name { get; }
    public DateTime DateTime { get; }
    private Vaccination(VaccinationId id, string name, DateTime dateTime)
        : base(id)
    {
        Name = name;
        DateTime = dateTime;
    }

    public static Vaccination Create(string name, DateTime dateTime)
    {
        return new(VaccinationId.CreateUnique(), name, dateTime);
    }
#pragma warning disable CS8618
    private Vaccination()
    {

    }
#pragma warning restore CS8618 
}
