using Application.Exceptions.Helpers;
using Application.Features.Urls.Constants;
using Application.Rules;
using Application.Services.Repository;
using Application.Services.Urls;
using Domain.Entities;

namespace Application.Features.Urls.Rules
{
    public class UrlBusinessRules : BusinessRulesBase
    {
        private readonly IAppDbContext _dbContext;
        private readonly IUrlService _urlService;

        public UrlBusinessRules(IAppDbContext dbContext, IUrlService urlService)
        {
            _dbContext = dbContext;
            _urlService = urlService;
        }

        public async Task UrlMustExistsAsync(Url? url)
        {
            if (url == null)
                ThrowHelper.ThrowNotFoundException(UrlMessages.UrlNotFound);
        }

        public async Task UrlMustBeActiveAsync(Url url)
        {
            if (url.ExpirationDate < DateTime.UtcNow)
                ThrowHelper.ThrowNotFoundException(UrlMessages.UrlExpired);
        }
    }
}
