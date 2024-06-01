using Application.Services.Repository;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace Application.Services.Urls
{
    public class UrlManager : IUrlService
    {
        private readonly IAppDbContext _dbContext;

        public UrlManager(IAppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync(Url url)
        {
            await _dbContext.Urls.AddAsync(url);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<Url?> GetByIdAsync(Guid? id)
        {
            var url = await _dbContext.Urls.SingleOrDefaultAsync(x => x.Id == id);
            return url;
        }

        public async Task<Url?> GetByShortUrlAsync(string? shortUrl)
        {
            var url = await _dbContext.Urls.SingleOrDefaultAsync(x => x.ShortUrl == shortUrl);
            return url;
        }

        public string GetRandomShortUrl(int length)
        {
            var random = new Random();
            const string chars = "abcdefghijklmnopqrstuvwxyz0123456789";
            var builder = new StringBuilder();
            for (var i = 0; i < length; i++)
            {
                var c = chars[random.Next(0, chars.Length)];
                builder.Append(c);
            }
            return builder.ToString();
        }
    }
}
