
using shelter.Application.Common.Interfaces.Authentication;

namespace shelter.Application.Services.Authentications;

public class AuthenticationsService : IAuthenticationsService
{
    private readonly IJwtTokenGenerator jwtTokenGenerator;

    public AuthenticationsService(IJwtTokenGenerator jwtTokenGenerator)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    public AuthenticationsResult Login(string email, string password)
    {
        return new AuthenticationsResult(
            Guid.NewGuid(), 
            "firstName",
            "lastName",
            email,
            Guid.NewGuid(),
            "phone",
            "token");
    }

    public AuthenticationsResult Register(string firstName, string lastName, string email, Guid idUserRole, string phone, string password)
    {
        Guid userId = Guid.NewGuid();

        var token = jwtTokenGenerator.GenerateToken(userId, firstName, lastName);

        return new AuthenticationsResult(
            userId,
            firstName,
            lastName,
            email,
            idUserRole,
            phone,
            token);
    }
}
