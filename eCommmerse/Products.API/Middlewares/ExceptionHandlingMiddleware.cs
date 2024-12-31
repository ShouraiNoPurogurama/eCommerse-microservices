using Microsoft.AspNetCore.Mvc;

namespace Products.API.Middlewares;

public class ExceptionHandlingMiddleware(ILogger<ExceptionHandlingMiddleware> logger) : IMiddleware
{
    public async Task InvokeAsync(HttpContext context, RequestDelegate next)
    {
        try
        {
            await next.Invoke(context);
        }
        catch (Exception e)
        {
            if (e.InnerException is not null)
            {
                logger.LogError("{exceptionName}: {message}", e.InnerException.GetType().ToString(), e.InnerException.Message);
            }

            context.Response.StatusCode = 500;
            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Detail = e.Message,
                Type = e.GetType().ToString(),
                Instance = context.TraceIdentifier
            });
        }
    }
}