using shelter.Domain.Animal.ValueObjects;
using shelter.Domain.Common.Models;

namespace shelter.Domain.Animal.Entities;

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
}
