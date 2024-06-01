using Application.Features.Urls.Constants;
using FluentValidation;

namespace Application.Features.Urls.Commands.Create
{
    public class CreateUrlCommandRequestValidator : AbstractValidator<CreateUrlCommandRequest>
    {
        public CreateUrlCommandRequestValidator()
        {
            RuleFor(x => x.Url)
                .NotNull()
                    .WithMessage(UrlMessages.UrlCannotBeNull);

            When(x => x.Url != null, () =>
            {
                RuleFor(x => x.Url.FullUrl)
                    .Must(x => !string.IsNullOrEmpty(x))
                        .WithMessage(UrlMessages.FullUrlCannotBeNull)
                    .Must(x => x.StartsWith("http"))
                        .WithMessage(UrlMessages.InvalidUrl);

                RuleFor(x => x.Url.ExpirationDate)
                    .NotNull()
                        .WithMessage(UrlMessages.ExpirationDateCannotBeNull)
                    .Must(x => x > DateTime.UtcNow)
                        .WithMessage(UrlMessages.InvalidExpirationDate);
            });
        }
    }
}