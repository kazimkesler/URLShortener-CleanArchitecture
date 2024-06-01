using Application.Extensions;
using Application.Pipelines.CacheRemoving;
using Application.Pipelines.Caching;
using Application.Pipelines.Validation;
using Application.Rules;
using Application.Services.Urls;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application
{
    public static class ApplicationServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddMediatR(config =>
            {
                config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
                config.AddOpenBehavior(typeof(ValidationBehavior<,>));
                config.AddOpenBehavior(typeof(CacheRemovingBehavior<,>));
                config.AddOpenBehavior(typeof(CachingBehavior<,>));
            });

            services.AddScoped<IUrlService, UrlManager>();

            services.AddAutoMapper(config =>
                config.AddMaps(Assembly.GetExecutingAssembly()));

            services.AddSubClassesOfType(Assembly.GetExecutingAssembly(), typeof(BusinessRulesBase));

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
