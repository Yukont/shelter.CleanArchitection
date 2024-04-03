namespace shelter.Contracts.Authentications;
public record RegisterRequest(
    string FirstName,
    string LastName,
    string Email,
    Guid IdUserRole,
    string Phone,
    string Password);
