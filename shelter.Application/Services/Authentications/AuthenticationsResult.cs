using shelter.Domain.Models;

namespace shelter.Application.Services.Authentications;

public record AuthenticationsResult(
    User User,
    string Token);
