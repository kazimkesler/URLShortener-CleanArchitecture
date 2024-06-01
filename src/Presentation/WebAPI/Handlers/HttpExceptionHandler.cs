using Application.Exceptions.Handlers;
using Application.Exceptions.Types;
using WebAPI.Extensions;
using WebAPI.HttpProblemDetails;

namespace WebAPI.Handlers
{
    public class HttpExceptionHandler : IExceptionHandler
    {
        private readonly HttpResponse _response;

        public HttpExceptionHandler(HttpResponse response)
        {
            _response = response;
        }

        public async Task HandleBusinessException(BusinessException businessException)
        {
            var response = new BusinessProblemDetails(businessException.Message);
            _response.StatusCode = response.StatusCode;
            await _response.WriteAsync(response.ToJson());
        }

        public async Task HandleValidationException(ValidationException validationException)
        {
            var response = new ValidationProblemDetails(validationException.Message, validationException.Errors);
            _response.StatusCode = response.StatusCode;
            await _response.WriteAsync(response.ToJson());
        }

        public async Task HandleUnauthorizedException(UnauthorizedException unauthorizedException)
        {
            var response = new UnauthorizedProblemDetails(unauthorizedException.Message);
            _response.StatusCode = response.StatusCode;
            await _response.WriteAsync(response.ToJson());
        }

        public async Task HandleForbiddenException(ForbiddenException forbiddenException)
        {
            var response = new ForbiddenProblemDetails(forbiddenException.Message);
            _response.StatusCode = response.StatusCode;
            await _response.WriteAsync(response.ToJson());
        }

        public async Task HandleNotFoundException(NotFoundException notFoundException)
        {
            var response = new NotFoundProblemDetails(notFoundException.Message);
            _response.StatusCode = response.StatusCode;
            await _response.WriteAsync(response.ToJson());
        }

        public async Task HandleException(Exception exception)
        {
            var response = new InternalProblemDetails();
            _response.StatusCode = response.StatusCode;
            await _response.WriteAsync(response.ToJson());
        }
    }
}
