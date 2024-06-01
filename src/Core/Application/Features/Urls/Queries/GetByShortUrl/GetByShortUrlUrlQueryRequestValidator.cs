using Application.Features.Urls.Constants;
using FluentValidation;

namespace Application.Features.Urls.Queries.GetByShortUrl
{
    public class GetByShortUrlUrlQueryRequestValidator : AbstractValidator<GetByShortUrlUrlQueryRequest>
    {
        public GetByShortUrlUrlQueryRequestValidator()
        {
            RuleFor(x => x.Url)
                .NotNull()
                    .WithMessage(UrlMessages.UrlCannotBeNull);

            When(x => x.Url != null, () =>
            {
                RuleFor(x => x.Url.ShortUrl)
                    .Must(x => !string.IsNullOrEmpty(x))
                        .WithMessage(UrlMessages.ShortUrlCannotBeNull)
                    .MaximumLength(20)
                        .WithMessage(UrlMessages.ShortUrlTooLong);
            });
        }
    }
}