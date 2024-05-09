using ErrorOr;
using MediatR;
using shelter.Application.Authentication.Common;
using shelter.Application.Common.Interfaces.Authentication;
using shelter.Application.Common.Interfaces.Persistence;
using shelter.Domain.Common.Errors;
using shelter.Domain.User;

namespace shelter.Application.Authentication.Queries.Login;

public class LoginQueryHandler : IRequestHandler<LoginQuery, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository userRepository;
    private readonly IJwtTokenGenerator jwtTokenGenerator;

    public LoginQueryHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        this.userRepository = userRepository;
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(LoginQuery query, CancellationToken cancellationToken)
    {
        if (userRepository.GetUserByEmail(query.Email) is not User user)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        if (user.Password != query.Password)
        {
            return Errors.Authentication.InvalidCredentials;
        }

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
