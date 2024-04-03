
namespace shelter.Application.Services.Authentications;

public class AuthenticationsService : IAuthenticationsService
{
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
        return new AuthenticationsResult(
            Guid.NewGuid(),
            firstName,
            lastName,
            email,
            idUserRole,
            phone,
            "token");
    }
}
