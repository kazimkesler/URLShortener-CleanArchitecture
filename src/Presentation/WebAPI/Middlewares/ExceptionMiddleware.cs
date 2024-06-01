using Application.Exceptions.Types;
using System.Net.Mime;
using WebAPI.Handlers;

namespace WebAPI.Middlewares
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception exception)
            {
                await HandleExceptionAsync(httpContext.Response, exception);
            }
        }

        private async Task HandleExceptionAsync(HttpResponse response, Exception exception)
        {
            response.ContentType = MediaTypeNames.Application.Json;
            var httpExceptionHandler = new HttpExceptionHandler(response);
            switch (exception)
            {
                case BusinessException businessException:
                    await httpExceptionHandler.HandleBusinessException(businessException);
                    break;
                case UnauthorizedException unauthorizedException:
                    await httpExceptionHandler.HandleUnauthorizedException(unauthorizedException);
                    break;
                case ForbiddenException forbiddenException:
                    await httpExceptionHandler.HandleForbiddenException(forbiddenException);
                    break;
                case ValidationException validationException:
                    await httpExceptionHandler.HandleValidationException(validationException);
                    break;
                case NotFoundException notFoundException:
                    await httpExceptionHandler.HandleNotFoundException(notFoundException);
                    break;
                default:
                    await httpExceptionHandler.HandleException(exception);
                    break;
            }
        }
    }
}
