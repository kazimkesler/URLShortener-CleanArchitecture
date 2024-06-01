using Microsoft.OpenApi.Models;

namespace WebAPI.Extensions
{
    public static class SwaggerServiceExtensions
    {
        public static void AddSwaggerServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(option =>
            {
                //For XML documentation, if you get an error:
                //Go to properties of WebAPI -> Output
                //And enable "Documentation File" option
                option.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, "WebAPI.xml"));

                //For nested classes
                option.CustomSchemaIds(s => s.FullName.Replace("+", "."));

                //API info
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "URL Shortener", Version = "v1" });
            });
        }
    }
}
