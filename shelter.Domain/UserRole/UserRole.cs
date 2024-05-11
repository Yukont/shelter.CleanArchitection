using shelter.Domain.Common.Models;
using shelter.Domain.UserRole.ValueObjects;

namespace shelter.Domain.UserRole;

public sealed class UserRole : AggregateRoot<UserRoleId>
{
    public string Name { get; }
    private UserRole(UserRoleId id, string name)
        : base(id)
    {
        Name = name;
    }

    public static UserRole Create(string name)
    {
        return new(UserRoleId.CreateUnique(), name);
    }
}
