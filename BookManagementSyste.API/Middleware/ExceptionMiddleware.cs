using BookManagementSystem.API.Models;
using BookManagementSystem.Application.Exceptions;
using System.Net;

namespace BookManagementSystem.API.Middleware;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        HttpStatusCode statusCode = HttpStatusCode.InternalServerError;
        CustomProblemDetails problem = new();
        switch (ex)
        {
            case BadRequestException badRequestException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomProblemDetails
                {
                    Title = badRequestException.Message,
                    Status = (int)statusCode,
                    Detail = badRequestException.InnerException?.ToString(),
                    Type = nameof(BadRequestException),
                };

                break;

            case NotFoundException notFoundException:
                statusCode = HttpStatusCode.NotFound;
                problem = new CustomProblemDetails
                {
                    Title = notFoundException.Message,
                    Status = (int)statusCode,
                    Detail = notFoundException.InnerException?.ToString(),
                    Type = nameof(NotFoundException),
                };
                break;
            case DatabaseUpdateException databaseUpdateException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomProblemDetails
                {
                    Title = databaseUpdateException.Message,
                    Status = (int)statusCode,
                    Detail = databaseUpdateException.InnerException?.ToString(),
                    Type = nameof(DatabaseUpdateException),
                };

                break;

            case FluentValidationException fluentValidationException:
                statusCode = HttpStatusCode.BadRequest;
                problem = new CustomProblemDetails
                {
                    Title = fluentValidationException.Message,
                    Status = (int)statusCode,
                    Detail = fluentValidationException.InnerException?.ToString(),
                    Type = nameof(FluentValidationException),
                    Errors = fluentValidationException.ValidationErrors
                };
                break;
            default:
                break;
        }

        context.Response.StatusCode = (int)statusCode;
        await context.Response.WriteAsJsonAsync(problem);
    }
}
