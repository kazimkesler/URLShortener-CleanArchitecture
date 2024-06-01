using Application.Features.Urls.Rules;
using Application.Services.Urls;
using AutoMapper;
using Domain.Entities;
using MediatR;

namespace Application.Features.Urls.Commands.Create
{
    public partial class CreateUrlCommandRequest
    {
        public class CreateUrlCommandHandler : IRequestHandler<CreateUrlCommandRequest, CreateUrlCommandResponse>
        {
            private readonly IUrlService _urlService;
            private readonly IMapper _mapper;
            private readonly UrlBusinessRules _urlBusinessRules;

            public CreateUrlCommandHandler(IUrlService urlService, IMapper mapper, UrlBusinessRules urlBusinessRules)
            {
                _urlService = urlService;
                _mapper = mapper;
                _urlBusinessRules = urlBusinessRules;
            }

            public async Task<CreateUrlCommandResponse> Handle(CreateUrlCommandRequest request, CancellationToken cancellationToken)
            {
                var url = _mapper.Map<Url>(request.Url);
                url.ShortUrl = _urlService.GetRandomShortUrl(20);
                await _urlService.AddAsync(url);
                return new CreateUrlCommandResponse()
                {
                    Url = _mapper.Map<CreateUrlCommandResponse.UrlDto>(url)
                };
            }
        }
    }
}
