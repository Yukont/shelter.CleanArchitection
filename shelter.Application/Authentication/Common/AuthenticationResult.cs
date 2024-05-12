using shelter.Domain.UserAggregate;

namespace shelter.Application.Authentication.Common;
public record AuthenticationResult(
    User User,
    string Token);
