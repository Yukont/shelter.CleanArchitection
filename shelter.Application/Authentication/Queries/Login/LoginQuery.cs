using ErrorOr;
using MediatR;
using shelter.Application.Authentication.Common;

namespace shelter.Application.Authentication.Queries.Login;

public record LoginQuery(
    string Email,
    string Password) : IRequest<ErrorOr<AuthenticationResult>>;
