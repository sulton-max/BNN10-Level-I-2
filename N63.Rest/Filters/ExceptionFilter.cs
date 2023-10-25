using System.ComponentModel.DataAnnotations;
using System.Net;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace N63.Rest.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var problemDetails = context.Exception switch
        {
            ValidationException => new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Detail = context.Exception.Message
            },
            InvalidOperationException => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Detail = context.Exception.Message
            },
            Exception => new ProblemDetails
            {
                Status = StatusCodes.Status500InternalServerError,
                Detail = context.Exception.Message
            }
        };

        context.ExceptionHandled = true;

        context.Result = new ObjectResult(problemDetails)
        {
            StatusCode = problemDetails.Status
        };
    }
}