using ErrorOr;
using Microsoft.AspNetCore.Mvc;
using shelter.Application.Services.Authentications;
using shelter.Contracts.Authentications;

namespace shelter.Api.Controllers;

[Route("auth")]
public class AuthenticationController : ApiController
{
    private readonly IAuthenticationsService authenticationsService;

    public AuthenticationController(IAuthenticationsService authenticationsService)
    {
        this.authenticationsService = authenticationsService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        ErrorOr<AuthenticationsResult> authResult = authenticationsService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.IdUserRole,
            request.Phone,
            request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors));
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = authenticationsService.Login(
            request.Email,
            request.Password);

        return authResult.Match(
            authResult => Ok(MapAuthResult(authResult)),
            errors => Problem(errors)
            );
    }
    private static AuthenticationResponse MapAuthResult(AuthenticationsResult authResult)
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
