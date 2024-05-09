using shelter.Domain.User;

namespace shelter.Application.Authentication.Common;
public record AuthenticationResult(
    User User,
    string Token);
