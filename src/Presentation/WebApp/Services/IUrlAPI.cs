using Refit;
using WebApp.Contracts.Urls.Create;
using WebApp.Contracts.Urls.GetByShortUrl;

namespace WebApp.Services
{
    public interface IUrlAPI
    {
        [Post("/urls")]
        Task<CreateUrlResponse> CreateUrl(CreateUrlRequest request);

        [Get("/r/{shortUrl}")]
        Task<GetByShortUrlResponse> GetByShortUrl(string shortUrl);
    }
}
