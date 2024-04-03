namespace shelter.Application.Services.Authentications;

public record AuthenticationsResult(Guid Id,
    string FirstName,
    string LastName,
    string Email,
    Guid IdUserRole,
    string Phone,
    string Token);
