using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace shelter.Api.Fillters;

public class ErrorHandingFillterAttribute : ExceptionFilterAttribute
{
    public override void OnException(ExceptionContext context)
    {
        var exception = context.Exception;

        var problemDetails = new ProblemDetails
        {
            Title = "Mistake",
            Status = (int)HttpStatusCode.InternalServerError
        };

        context.Result = new ObjectResult(problemDetails);

        context.ExceptionHandled = true;
        //base.OnException(context);
    }
}
