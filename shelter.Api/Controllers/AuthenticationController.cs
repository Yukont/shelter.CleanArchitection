using ErrorOr;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using shelter.Application.Authentication.Commands.Register;
using shelter.Application.Authentication.Common;
using shelter.Application.Authentication.Queries.Login;
using shelter.Contracts.Authentications;

namespace shelter.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly ISender mediator;

    public AuthenticationController(ISender mediator)
    {
        this.mediator = mediator;
    }

    [HttpPost("register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterCommand(request.FirstName, request.LastName, request.Email, request.IdUserRole, request.Phone, request.Password);
        ErrorOr<AuthenticationResult> authResult = await mediator.Send(command);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(request.Email, request.Password);
        var authResult = await mediator.Send(query);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
            );
    }
    private static AuthenticationResponse MapAuthResult(AuthenticationResult authResult)
    {
        return new AuthenticationResponse(
                    authResult.User.Id,
                    authResult.User.FirstName,
                    authResult.User.LastName,
                    authResult.User.Email,
                    authResult.User.IdUserRole,
                    authResult.User.Phone,
                    authResult.Token);
    }
}
