using shelter.Domain.UserAggregate;

namespace shelter.Application.Common.Interfaces.Authentication;

public interface IJwtTokenGenerator
{
    string GenerateToken(User user);
}
