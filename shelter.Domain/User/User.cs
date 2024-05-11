using shelter.Domain.Common.Models;
using shelter.Domain.User.ValueObjects;
using shelter.Domain.UserRole.ValueObjects;

namespace shelter.Domain.User;

public sealed class User : AggregateRoot<UserId>
{
    public string FirstName { get; }
    public string LastName { get; }
    public string Email { get; }
    public UserRoleId UserRoleId { get; }
    public string Phone { get; }
    public string Password { get; }

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
}
