using My.AspNetCore.WebForms.Infrastructure;
using My.AspNetCore.WebForms.Templating;
using System;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebFormsServiceCollectionExtensions
    {
        public static IServiceCollection AddWebForms(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddOptions();

            AddWebFormsServices(services);

            return services;
        }

        public static IServiceCollection AddWebForms(this IServiceCollection services, Action<WebFormsOptions> setupAction)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            if (setupAction == null)
            {
                throw new ArgumentNullException(nameof(setupAction));
            }

            AddWebFormsServices(services, setupAction);

            return services;
        }

        private static void AddWebFormsServices(this IServiceCollection services)
        {
            services.AddSingleton<IPageFactory, PageFactory>();
            services.AddSingleton<ITemplate, NullTemplate>();
        }

        private static void AddWebFormsServices(this IServiceCollection services, Action<WebFormsOptions> setupAction)
        {
            AddWebFormsServices(services);
            services.Configure(setupAction);
        }
    }
}
