using System.Text.Json;

namespace MediaHub.API.Middlewares;

public class ExceptionHandlingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<ExceptionHandlingMiddleware> _logger;

    public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
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

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        int statusCode = 500;
        string message = string.Empty;

        switch (exception)
        {
            case KeyNotFoundException:
                statusCode = StatusCodes.Status404NotFound;
                message = exception.Message ?? "Resource not found.";
                break;
            case ArgumentException:
                statusCode = StatusCodes.Status400BadRequest;
                message = exception.Message ?? "Invalid argument.";
                break;
            default:
                statusCode = StatusCodes.Status500InternalServerError;
                message = "An unexpected error occurred. Please try again later.";
                break;
        }

        // Log detailed information
        _logger.LogError(exception, "An error occurred while processing the request. " +
                                    "Request Path: {Path}, Method: {Method}, QueryString: {QueryString}",
                                    context.Request.Path,
                                    context.Request.Method,
                                    context.Request.QueryString);

        context.Response.ContentType = "application/json";
        context.Response.StatusCode = statusCode;

        var errorResponse = new
        {
            StatusCode = statusCode,
            Message = message,
            Details = exception.Message ?? "No additional details available."
        };

        // Serialize the response to JSON
        return context.Response.WriteAsync(JsonSerializer.Serialize(errorResponse));
    }
}
