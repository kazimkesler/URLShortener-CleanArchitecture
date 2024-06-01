namespace WebApp.Contracts.Urls.Create
{
    public class CreateUrlRequest
    {
        public UrlDto? Url { get; set; }

        public class UrlDto
        {
            public string? FullUrl { get; set; }
            public DateTime? ExpirationDate { get; set; }
        }
    }
}
