using shelter.Domain.AnimalAggregate.Entities;
using shelter.Domain.Common.Models;
using shelter.Domain.UserAggregate;
using shelter.Domain.UserRoleAggregate.ValueObjects;

namespace shelter.Domain.UserRoleAggregate;

public sealed class UserRole : AggregateRoot<UserRoleId>
{
    public string Name { get; private set; }

    private readonly List<User> _users = new();
    public IReadOnlyList<User> Users => _users.AsReadOnly();
    private UserRole(UserRoleId id, string name)
        : base(id)
    {
        Name = name;
    }

    public static UserRole Create(string name)
    {
        return new(UserRoleId.CreateUnique(), name);
    }
#pragma warning disable CS8618
    private UserRole()
    {

    }
#pragma warning restore CS8618 
}
