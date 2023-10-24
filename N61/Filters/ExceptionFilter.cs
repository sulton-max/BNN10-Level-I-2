using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using N61.Models.CustomExceptions;

namespace N61.Filters;

public class ExceptionFilter : IExceptionFilter
{
    public void OnException(ExceptionContext context)
    {
        var problemDetails = context.Exception switch
        {
            EntityNotFoundException => new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Detail = context.Exception.Message
            },
            EntityConflictException => new ProblemDetails
            {
                Status = StatusCodes.Status409Conflict,
                Detail = context.Exception.Message
            },
            InvalidEntityException => new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
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