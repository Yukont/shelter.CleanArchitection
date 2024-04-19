using ErrorOr;
using MediatR;
using shelter.Application.Common.Interfaces.Authentication;
using shelter.Application.Common.Interfaces.Persistence;
using shelter.Domain.Models;
using shelter.Domain.Common.Errors;
using shelter.Application.Authentication.Common;

namespace shelter.Application.Authentication.Commands.Register;

public class RegisterCommandHandler : IRequestHandler<RegisterCommand, ErrorOr<AuthenticationResult>>
{
    private readonly IUserRepository userRepository;
    private readonly IJwtTokenGenerator jwtTokenGenerator;

    public RegisterCommandHandler(IUserRepository userRepository, IJwtTokenGenerator jwtTokenGenerator)
    {
        this.userRepository = userRepository;
        this.jwtTokenGenerator = jwtTokenGenerator;
    }

    public async Task<ErrorOr<AuthenticationResult>> Handle(RegisterCommand command, CancellationToken cancellationToken)
    {
        if (userRepository.GetUserByEmail(command.Email) is not null)
        {
            return Errors.User.DublicateEmail;
        }

        var user = new User
        {
            FirstName = command.FirstName,
            LastName = command.LastName,
            Email = command.Email,
            IdUserRole = command.IdUserRole,
            Phone = command.Phone,
            Password = command.Password
        };

        userRepository.Add(user);

        var token = jwtTokenGenerator.GenerateToken(user);

        return new AuthenticationResult(
            user,
            token);
    }
}
