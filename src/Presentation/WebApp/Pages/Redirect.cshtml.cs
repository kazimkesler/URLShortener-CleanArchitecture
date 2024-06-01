using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Refit;
using System.Net;
using WebApp.Options;
using WebApp.Services;

namespace WebApp.Pages
{
    public class RedirectModel : PageModel
    {
        private readonly IUrlAPI _todoAPI;
        private readonly WebAppOptions _wepAppOptions;

        public RedirectModel(IUrlAPI todoAPI, IOptions<WebAppOptions> wepAppOptions)
        {
            _todoAPI = todoAPI;
            _wepAppOptions = wepAppOptions.Value;
        }

        public async Task<IActionResult> OnGet(string shortUrl)
        {
            try
            {
                var response = await _todoAPI.GetByShortUrl(shortUrl);
                return RedirectPermanent(response.Url.FullUrl);
            }
            catch (ApiException exception)
            {
                if (exception.StatusCode == HttpStatusCode.NotFound)
                    return NotFound();
            }
            return Page();
        }
    }
}
