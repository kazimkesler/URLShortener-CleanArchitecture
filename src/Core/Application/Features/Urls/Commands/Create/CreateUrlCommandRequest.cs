using Application.Requests;
using MediatR;

namespace Application.Features.Urls.Commands.Create
{
    public partial class CreateUrlCommandRequest : RequestBase, IRequest<CreateUrlCommandResponse>
    {
        public UrlDto? Url { get; set; }

        public class UrlDto
        {
            public string? FullUrl { get; set; }
            public DateTime? ExpirationDate { get; set; }
        }
    }
}
