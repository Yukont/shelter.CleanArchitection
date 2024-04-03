namespace shelter.Application.Services.Authentications;

public interface IAuthenticationsService
{
    AuthenticationsResult Login(string email, string password);
    AuthenticationsResult Register(string firstName, string lastName, string email, Guid idUserRole ,string phone, string password); 
}
