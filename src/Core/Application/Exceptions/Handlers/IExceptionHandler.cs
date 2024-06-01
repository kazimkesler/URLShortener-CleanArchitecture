using Application.Exceptions.Types;

namespace Application.Exceptions.Handlers
{
    public interface IExceptionHandler
    {
        Task HandleBusinessException(BusinessException businessException);
        Task HandleValidationException(ValidationException validationException);
        Task HandleUnauthorizedException(UnauthorizedException unauthorizedException);
        Task HandleForbiddenException(ForbiddenException forbiddenException);
        Task HandleNotFoundException(NotFoundException notFoundException);
        Task HandleException(Exception exception);
    }
}
