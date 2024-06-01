using Application.Responses;

namespace Application.Features.Urls.Queries.GetByShortUrl
{
    public class GetByShortUrlUrlQueryResponse : ResponseBase
    {
        public UrlDto Url { get; set; }

        public class UrlDto
        {
            public Guid Id { get; set; }
            public string FullUrl { get; set; }
            public string ShortUrl { get; set; }
            public DateTime ExpirationDate { get; set; }
        }
    }
}
