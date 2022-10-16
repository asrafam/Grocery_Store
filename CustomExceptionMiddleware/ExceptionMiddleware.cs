
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System.Threading.Tasks;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;
    private readonly ILogger _logger;

    public ExceptionMiddleware(RequestDelegate next, ILoggerFactory logFactory)
    {
        _next = next;

        _logger = logFactory.CreateLogger("ExceptionMiddleware");
    }

    public async Task Invoke(HttpContext httpContext)
    {
        try
        {
            _logger.LogInformation("ExceptionMiddleware executing..");

            await _next(httpContext); // calling next middleware
        }
        //catch (UnAuthorizedAccessException)
        //{
        //    httpContext.Response.Redirect("/Error");
        //}
        catch (Exception ex)
        {
            httpContext.Response.Redirect("/Error");
        }

    }
   
}

// Extension method used to add the middleware to the HTTP request pipeline.
public static class ExceptionMiddlewareExtensions
{
    public static IApplicationBuilder UseExceptionMiddleware(this IApplicationBuilder builder)
    {
        return builder.UseMiddleware<ExceptionMiddleware>();
    }
}