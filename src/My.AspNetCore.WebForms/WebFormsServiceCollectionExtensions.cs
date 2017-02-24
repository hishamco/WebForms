using My.AspNetCore.WebForms.Infrastructure;
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

            return services;
        }
    }
}
