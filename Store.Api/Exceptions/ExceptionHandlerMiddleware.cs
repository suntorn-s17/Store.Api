using Store.Api.DTOs.Responses;

namespace Store.Api.Exceptions
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception error)
            {
                var response = httpContext.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case DomainException:
                        response.StatusCode = StatusCodes.Status400BadRequest;
                        await response.WriteAsJsonAsync(new ExceptionHandlerResponse
                        {
                            StatusCode = response.StatusCode,
                            Message = error.Message
                        });
                        break;

                    case NotFoundException:
                        response.StatusCode = StatusCodes.Status404NotFound;
                        await response.WriteAsJsonAsync(new ExceptionHandlerResponse
                        {
                            StatusCode = response.StatusCode,
                            Message = error.Message
                        });
                        break;

                    case UnauthorizeException:
                        response.StatusCode = StatusCodes.Status401Unauthorized;
                        await response.WriteAsJsonAsync(new ExceptionHandlerResponse
                        {
                            StatusCode = response.StatusCode,
                            Message = error.Message
                        });
                        break;

                    default:
                        response.StatusCode = StatusCodes.Status500InternalServerError;
                        await response.WriteAsJsonAsync(new ExceptionHandlerResponse
                        {
                            StatusCode = response.StatusCode,
                            Message = error.Message
                        });
                        break;
                }
            }
        }
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class DomainExceptionHandlerMiddlewareExtensions
    {
        public static IApplicationBuilder UseExceptionHandlerMiddleware(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionHandlerMiddleware>();
        }
    }
}