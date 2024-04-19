using shelter.Domain.Models;

namespace shelter.Application.Authentication.Common;
public record AuthenticationResult(
    User User,
    string Token);
