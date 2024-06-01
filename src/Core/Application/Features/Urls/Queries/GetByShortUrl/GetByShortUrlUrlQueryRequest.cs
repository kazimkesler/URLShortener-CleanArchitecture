using Application.Requests;
using MediatR;

namespace Application.Features.Urls.Queries.GetByShortUrl
{
    public partial class GetByShortUrlUrlQueryRequest : RequestBase, IRequest<GetByShortUrlUrlQueryResponse>
    {
        public UrlDto? Url { get; set; }

        public class UrlDto
        {
            public string? ShortUrl { get; set; }
        }
    }
}
