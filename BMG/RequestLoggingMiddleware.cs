using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public class RequestLoggingMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger<RequestLoggingMiddleware> _logger;

    public RequestLoggingMiddleware(RequestDelegate next, ILogger<RequestLoggingMiddleware> logger)
    {
        _next = next;
        _logger = logger;
    }

    public async Task InvokeAsync(HttpContext context)
    {
       _logger.LogInformation("Handling request: {Method} {Path} at {Time}", context.Request.Method, context.Request.Path, DateTime.Now);

        // Call the next delegate/middleware in the pipeline
        await _next(context);

        _logger.LogInformation("Finished handling request.");
    }
}