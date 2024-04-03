using Microsoft.AspNetCore.Mvc;
using shelter.Application.Services.Authentications;
using shelter.Contracts.Authentications;

namespace shelter.Api.Controllers;

[ApiController]
[Route("auth")]
public class AuthenticationController : Controller
{
    private readonly IAuthenticationsService authenticationsService;

    public AuthenticationController(IAuthenticationsService authenticationsService)
    {
        this.authenticationsService = authenticationsService;
    }

    [HttpPost("register")]
    public IActionResult Register(RegisterRequest request)
    {
        var authResult = authenticationsService.Register(
            request.FirstName,
            request.LastName,
            request.Email,
            request.IdUserRole,
            request.Phone,
            request.Password);

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.IdUserRole,
            authResult.Phone,
            authResult.Token);

        return Ok(response);
    }

    [HttpPost("login")]
    public IActionResult Login(LoginRequest request)
    {
        var authResult = authenticationsService.Login(
            request.Email,
            request.Password);

        var response = new AuthenticationResponse(
            authResult.Id,
            authResult.FirstName,
            authResult.LastName,
            authResult.Email,
            authResult.IdUserRole,
            authResult.Phone,
            authResult.Token);

        return Ok(response);
    }
}
