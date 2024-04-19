using ErrorOr;
using MediatR;
using shelter.Application.Authentication.Common;

namespace shelter.Application.Authentication.Commands.Register;

public record RegisterCommand(
    string FirstName,
    string LastName,
    string Email,
    Guid IdUserRole,
    string Phone,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
