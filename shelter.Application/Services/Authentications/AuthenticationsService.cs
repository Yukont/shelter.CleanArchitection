using ErrorOr;
using shelter.Application.Common.Errors;
using shelter.Application.Common.Interfaces.Authentication;
using shelter.Application.Common.Interfaces.Persistence;
using shelter.Domain.Common.Errors;
using shelter.Domain.Models;

namespace shelter.Application.Services.Authentications;

public class AuthenticationsService : IAuthenticationsService
{
    private readonly IUserRepository userRepository;
    private readonly IJwtTokenGenerator jwtTokenGenerator;

    public AuthenticationsService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
    {
        this.jwtTokenGenerator = jwtTokenGenerator;
        this.userRepository = userRepository;
    }

    public ErrorOr<AuthenticationsResult> Login(string email, string password)
    {
        if (userRepository.GetUserByEmail(email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if(user.Password !=  password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationsResult(
            user,
            token);
    }

    public ErrorOr<AuthenticationsResult> Register(string firstName, string lastName, string email, Guid idUserRole, string phone, string password)
    {
        if (userRepository.GetUserByEmail(email) is not null)
        {
            return Errors.User.DublicateEmail;
        }

        var user = new User
        {
            FirstName = firstName,
            LastName = lastName,
            Email = email,
            IdUserRole = idUserRole,
            Phone = phone,
            Password = password
        };

        userRepository.Add(user);

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationsResult(
            user,
            token);
    }
}
