using Application.Features.Urls.Rules;
using Application.Pipelines.Caching;
using Application.Services.Urls;
using AutoMapper;
using MediatR;

namespace Application.Features.Urls.Queries.GetByShortUrl
{
    public partial class GetByShortUrlUrlQueryRequest : ICachableRequest
    {
        public string CacheKey => Url.ShortUrl;

        public class GetByShortUrlUrlQueryHandler : IRequestHandler<GetByShortUrlUrlQueryRequest, GetByShortUrlUrlQueryResponse>
        {
            private readonly IUrlService _urlService;
            private readonly IMapper _mapper;
            private readonly UrlBusinessRules _urlBusinessRules;

            public GetByShortUrlUrlQueryHandler(IUrlService urlService, IMapper mapper, UrlBusinessRules urlBusinessRules)
            {
                _urlService = urlService;
                _mapper = mapper;
                _urlBusinessRules = urlBusinessRules;
            }

            public async Task<GetByShortUrlUrlQueryResponse> Handle(GetByShortUrlUrlQueryRequest request, CancellationToken cancellationToken)
            {
                var url = await _urlService.GetByShortUrlAsync(request.Url.ShortUrl);

                await _urlBusinessRules.UrlMustExistsAsync(url);
                await _urlBusinessRules.UrlMustBeActiveAsync(url);

                return new GetByShortUrlUrlQueryResponse()
                {
                    Url = _mapper.Map<GetByShortUrlUrlQueryResponse.UrlDto>(url)
                };
            }
        }
    }
}
