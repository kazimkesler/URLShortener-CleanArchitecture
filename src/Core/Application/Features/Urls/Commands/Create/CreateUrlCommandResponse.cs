using Application.Responses;

namespace Application.Features.Urls.Commands.Create
{
    public class CreateUrlCommandResponse : ResponseBase
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