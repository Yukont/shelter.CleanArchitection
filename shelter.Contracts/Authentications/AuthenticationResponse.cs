namespace shelter.Contracts.Authentications;

public record AuthenticationResponse (
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    Guid IdUserRole,
    string Phone,
    string Token);
