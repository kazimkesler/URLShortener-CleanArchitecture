using Application.Exceptions.Models;

namespace Application.Exceptions.Types
{
    public class ValidationException : Exception
    {
        public IEnumerable<ValidationExceptionModel> Errors { get; } = [];

        public ValidationException(string message, IEnumerable<ValidationExceptionModel> errors) : base(message)
        {
            Errors = errors;
        }
    }
}
