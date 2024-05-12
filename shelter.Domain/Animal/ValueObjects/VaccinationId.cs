using shelter.Domain.Common.Models;

namespace shelter.Domain.Animal.ValueObjects;

public sealed class VaccinationId : ValueObject
{
    public Guid Value { get; }

    private VaccinationId(Guid value)
    {
        Value = value;
    }

    public static VaccinationId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static VaccinationId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
