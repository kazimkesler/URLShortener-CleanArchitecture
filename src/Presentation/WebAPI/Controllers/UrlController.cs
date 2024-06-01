using Application.Features.Urls.Commands.Create;
using Application.Features.Urls.Queries.GetByShortUrl;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    /// <summary>
    /// This controller manages the URL operations
    /// </summary>
    [ApiController]
    [Route("api/")]
    public class UrlController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UrlController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// This endpoint gets the URL entity with short url text
        /// </summary>
        /// <param name="shortUrl">short url text of the URL entity</param>
        /// <returns>returns URL entity with short url text</returns>
        [HttpGet("r/{shortUrl}")]
        public async Task<IActionResult> GetByShortUrl([FromRoute] string shortUrl)
        {
            var request = new GetByShortUrlUrlQueryRequest()
            {
                Url = new()
                {
                    ShortUrl = shortUrl
                }
            };

            var response = await _mediator.Send(request);
            return Ok(response);
        }

        /// <summary>
        /// This endpoint adds an URL entity to database
        /// </summary>
        /// <param name="request">URL entity to be added</param>
        /// <returns>returns added URL entity</returns>
        [HttpPost("urls")]
        public async Task<IActionResult> Create([FromBody] CreateUrlCommandRequest request)
        {
            var response = await _mediator.Send(request);
            return CreatedAtAction(null, new { response.Url.ShortUrl }, response);
        }
    }
}
