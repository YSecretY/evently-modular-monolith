using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace Evently;

public class GlobalExceptionHandler : IExceptionHandler
{
    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        var problemDetails = exception switch
        {
            ValidationException => new ProblemDetails { Status = StatusCodes.Status400BadRequest, Title = "Validation error", Detail = exception.Message },
            FluentValidation.ValidationException validationException => new ProblemDetails
            {
                Status = StatusCodes.Status400BadRequest,
                Title = "Validation error",
                Extensions = GetValidationExceptionErrors(validationException)
            },
            KeyNotFoundException => new ProblemDetails { Status = StatusCodes.Status404NotFound, Title = "Not found", Detail = exception.Message },
            _ => new ProblemDetails { Status = StatusCodes.Status500InternalServerError, Title = "Internal server error" }
        };

        if (problemDetails.Status is not null)
            httpContext.Response.StatusCode = problemDetails.Status.Value;

        await httpContext.Response.WriteAsJsonAsync(problemDetails, cancellationToken);

        return true;
    }

    private static Dictionary<string, object?> GetValidationExceptionErrors(FluentValidation.ValidationException exception)
    {
        var resultErrors = new Dictionary<string, object?>();

        foreach (var error in exception.Errors)
            resultErrors.Add(error.PropertyName, error.ErrorMessage);

        return resultErrors;
    }
}