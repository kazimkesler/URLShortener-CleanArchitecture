namespace WebApp.Contracts.Urls.GetByShortUrl
{
    public class GetByShortUrlRequest
    {
        public UrlDto? Url { get; set; }

        public class UrlDto
        {
            public string? ShortUrl { get; set; }
        }
    }
}
