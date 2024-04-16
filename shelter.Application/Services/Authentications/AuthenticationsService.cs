using shelter.Application.Common.Errors;
using shelter.Application.Common.Interfaces.Authentication;
using shelter.Application.Common.Interfaces.Persistence;
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

    public AuthenticationsResult Login(string email, string password)
    {
        if (userRepository.GetUserByEmail(email) is not User user)
        {
            throw new Exception("User with given email does not exist");
        }

        if(user.Password !=  password)
        {
            throw new Exception("Invalid password");
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationsResult(
            user,
            token);
    }

    public AuthenticationsResult Register(string firstName, string lastName, string email, Guid idUserRole, string phone, string password)
    {
        if (userRepository.GetUserByEmail(email) is not null)
        {
            throw new DuplicateEmailException();
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
