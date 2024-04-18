using ErrorOr;

namespace shelter.Application.Services.Authentications;

public interface IAuthenticationsService
{
    ErrorOr<AuthenticationsResult> Login(string email, string password);
    ErrorOr<AuthenticationsResult> Register(string firstName, string lastName, string email, Guid idUserRole ,string phone, string password); 
}
