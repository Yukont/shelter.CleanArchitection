using shelter.Domain.Common.Models;

namespace shelter.Domain.AdoptionApplication.ValueObjects;

public sealed class AdoptionApplicationStatusId : ValueObject
{
    public Guid Value { get; }

    private AdoptionApplicationStatusId(Guid value)
    {
        Value = value;
    }

    public static AdoptionApplicationStatusId CreateUnique()
    {
        return new(Guid.NewGuid());
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
