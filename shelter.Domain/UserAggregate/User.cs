using shelter.Domain.Common.Models;
using shelter.Domain.UserAggregate.ValueObjects;
using shelter.Domain.UserRoleAggregate;
using shelter.Domain.UserRoleAggregate.ValueObjects;

namespace shelter.Domain.UserAggregate;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; private set; }
    public string LastName { get; private set; }
    public string Email { get; private set; }
    public UserRoleId UserRoleId { get; private set; }
    public UserRole? UserRole { get; private set; }
    public string Phone { get; private set; }
    public string Password { get; private set; }

    private User(
        UserId id,
        string firstName,
        string lastName,
        string email,
        UserRoleId userRoleId,
        string phone,
        string password)
        : base(id)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
        UserRoleId = userRoleId;
        Phone = phone;
        Password = password;
    }
    public static User Create(
        string firstName,
        string lastName,
        string email,
        UserRoleId userRoleId,
        string phone,
        string password)
    {
        return new(UserId.CreateUnique(), firstName, lastName, email, userRoleId, phone, password);
    }

    public void SetUserRole(UserRole userRole)
    {
        UserRole = userRole;
    }
#pragma warning disable CS8618
    private User()
    {

    }
#pragma warning restore CS8618 
}
