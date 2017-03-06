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

            services.AddSingleton<IPageFactory, PageFactory>();
            services.AddSingleton<ITemplate, NullTemplate>();

            return services;
        }
    }
}
