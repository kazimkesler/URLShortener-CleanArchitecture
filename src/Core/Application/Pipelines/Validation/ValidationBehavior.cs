using Application.Exceptions.Helpers;
using Application.Exceptions.Models;
using FluentValidation;
using MediatR;

namespace Application.Pipelines.Validation
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
        where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
                return await next();

            var context = new ValidationContext<object>(request);

            IEnumerable<ValidationExceptionModel> errors = _validators
                .Select(validator => validator.Validate(context))
                .SelectMany(result => result.Errors)
                .Where(failure => failure != null)
                .GroupBy(
                   keySelector: p => p.PropertyName,
                   resultSelector: (propertyName, errors) =>
                      new ValidationExceptionModel { Property = propertyName, Errors = errors.Select(e => e.ErrorMessage) }
                ).ToList();

            if (errors.Any())
                ThrowHelper.ThrowValidationException("Validation error!", errors);

            var response = await next();
            return response;
        }
    }
}
