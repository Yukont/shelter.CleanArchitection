﻿using shelter.Domain.Common.Models;

namespace shelter.Domain.UserRole.ValueObjects;

public sealed class UserRoleId : ValueObject
{
    public Guid Value { get; }

    private UserRoleId(Guid value)
    {
        Value = value;
    }

    public static UserRoleId CreateUnique()
    {
        return new(Guid.NewGuid());
    }
    public static UserRoleId Create(Guid value)
    {
        return new(value);
    }

    public override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}
