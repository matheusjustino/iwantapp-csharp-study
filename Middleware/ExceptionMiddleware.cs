namespace IWantApp.Middleware;

using IWantApp.ViewModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

public static class ExceptionMiddleware
{
    public static void ConfigureExceptionHandler(this IApplicationBuilder app, ILogger logger)
    {
        app.UseExceptionHandler(appError =>
        {
            appError.Run(async context =>
            {
                context.Response.ContentType = "application/json";

                var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                if (contextFeature != null)
                {
                    var exception = contextFeature.Error;
                    var errorMessage = exception.Message ?? "An error occurred. Please try again later.";

                    var errorResponse = new ErrorResponse
                    {
                        Message = errorMessage,
                        Endpoint = context.Request.Path,
                        StatusCode = GetStatusCode(exception),
                        Timestamp = DateTime.UtcNow,
                    };

                    logger.LogError(exception, errorMessage);

                    await context.Response.WriteAsync(errorResponse.ToString());
                }
            });
        });
    }

    private static int GetStatusCode(Exception exception)
    {
        if (exception is BadHttpRequestException)
        {
            return StatusCodes.Status404NotFound;
        }
        else if (exception is UnauthorizedAccessException)
        {
            return StatusCodes.Status401Unauthorized;
        }
        else
        {
            return StatusCodes.Status500InternalServerError;
        }
    }
}
