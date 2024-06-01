namespace WebApp.Contracts.Urls.Create
{
    public class CreateUrlResponse
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
