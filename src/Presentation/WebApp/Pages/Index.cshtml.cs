using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Options;
using Refit;
using System.Text.Json;
using WebApp.Contracts.Errors;
using WebApp.Contracts.Urls.Create;
using WebApp.Options;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUrlAPI _todoAPI;
        private readonly WebAppOptions _wepAppOptions;
        public string? ErrorMessage { get; set; }
        public string? ShortenedUrl { get; set; }
        public ErrorResponse ErrorResponse { get; set; }

        [BindProperty]
        public UrlViewModel UrlViewModel { get; set; }

        public IndexModel(IUrlAPI todoAPI, IOptions<WebAppOptions> wepAppOptions)
        {
            _todoAPI = todoAPI;
            _wepAppOptions = wepAppOptions.Value;
        }

        public async Task<IActionResult> OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
                return Page();
            try
            {
                var response = await _todoAPI.CreateUrl(new CreateUrlRequest()
                {
                    Url = new()
                    {
                        FullUrl = UrlViewModel.FullUrl,
                        ExpirationDate = UrlViewModel.Date.Add(UrlViewModel.Time)
                    }
                });
                ShortenedUrl = $"{_wepAppOptions.WebDomain}/r/{response.Url.ShortUrl}";
            }
            catch (ApiException exception)
            {
                ErrorResponse = JsonSerializer.Deserialize<ErrorResponse>(exception.Content, new JsonSerializerOptions { PropertyNamingPolicy = JsonNamingPolicy.CamelCase });

                if (ErrorResponse.Errors.Any(x => x.Property == "Url.FullUrl"))
                    ModelState.AddModelError("UrlViewModel.FullUrl", ErrorResponse.Errors.FirstOrDefault(x => x.Property == "Url.FullUrl")?.Errors?.Aggregate((x, y) => $"{x}\n{y}"));

                if (ErrorResponse.Errors.Any(x => x.Property == "Url.ExpirationDate"))
                {
                    ModelState.AddModelError("UrlViewModel.Date", ErrorResponse.Errors.FirstOrDefault(x => x.Property == "Url.ExpirationDate")?.Errors?.Aggregate((x, y) => $"{x}\n{y}"));
                    ModelState.AddModelError("UrlViewModel.Time", ErrorResponse.Errors.FirstOrDefault(x => x.Property == "Url.ExpirationDate")?.Errors?.Aggregate((x, y) => $"{x}\n{y}"));
                }
            }
            catch
            {
                ErrorMessage = "An unknown error occurred";
            }
            return Page();
        }
    }
}
