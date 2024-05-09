using shelter.Domain.Common.Models;
using shelter.Domain.User.ValueObjects;

namespace shelter.Domain.User.Entities;

public sealed class UserRole : Entity<UserRoleId>
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
