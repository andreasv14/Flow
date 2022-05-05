using Flow.ResourceManager.WebAPI.Models;
using System.Net;
using System.Text.Json;

namespace Flow.ResourceManager.WebAPI.Filters;

public class ErrorHandlerMiddleware
{
    private readonly RequestDelegate _next;

    public ErrorHandlerMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task Invoke(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception error)
        {
            var response = context.Response;
            response.ContentType = "application/json";

            var apiResponse = new ApiResponse
            {
                StatusCode = response?.StatusCode ?? (int)HttpStatusCode.OK,
                ErrorMessage = error?.Message
            };

            var result = JsonSerializer.Serialize(apiResponse);
            await response.WriteAsync(result);
        }
    }
}