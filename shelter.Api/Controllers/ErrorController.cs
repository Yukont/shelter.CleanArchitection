﻿using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using shelter.Application.Common.Errors;

namespace shelter.Api.Controllers;

public class ErrorController : ControllerBase
{
    [HttpPost]
    [Route("/error")]
    public IActionResult Error()
    {
        Exception? exception = HttpContext.Features.Get<IExceptionHandlerFeature>()?.Error;

        var (statusCode, message) = exception switch
        {
            DuplicateEmailException => (StatusCodes.Status409Conflict, "Email already exists."),
            _ => (StatusCodes.Status500InternalServerError, "An unexpected error occurred."),
        };

        return Problem(statusCode: statusCode, title: message);
    }
}
