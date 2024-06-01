using Application.Exceptions.Models;
using Application.Exceptions.Types;

namespace Application.Exceptions.Helpers
{
    public static class ThrowHelper
    {
        public static void ThrowBusinessException(string message)
            => throw new BusinessException(message);
        public static void ThrowValidationException(string message, IEnumerable<ValidationExceptionModel> errors)
            => throw new ValidationException(message, errors);
        public static void ThrowUnauthorizedException(string message)
            => throw new UnauthorizedException(message);
        public static void ThrowForbiddenException(string message)
            => throw new ForbiddenException(message);
        public static void ThrowNotFoundException(string message)
            => throw new NotFoundException(message);
    }
}
