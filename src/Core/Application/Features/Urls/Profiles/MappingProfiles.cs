using Application.Features.Urls.Commands.Create;
using Application.Features.Urls.Queries.GetByShortUrl;
using AutoMapper;
using Domain.Entities;

namespace Application.Features.Urls.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<CreateUrlCommandRequest.UrlDto, Url>();
            CreateMap<Url, CreateUrlCommandResponse.UrlDto>();

            CreateMap<Url, GetByShortUrlUrlQueryResponse.UrlDto>();
        }
    }
}
