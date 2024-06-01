using WebAPI.Options;

namespace WebAPI.Extensions
{
    public static class CorsMiddlewareExtensions
    {
        public static void ConfigureCorsMiddleware(this IApplicationBuilder app, IConfiguration configuration)
        {
            var webApiOptions = configuration.GetSection(typeof(WebAPIOptions).Name).Get<WebAPIOptions>();
            ArgumentNullException.ThrowIfNull(webApiOptions);
            app.UseCors(opt => opt.WithOrigins(webApiOptions.AllowedOrigins)
                .AllowAnyHeader().AllowAnyMethod().AllowCredentials());
        }
    }
}
