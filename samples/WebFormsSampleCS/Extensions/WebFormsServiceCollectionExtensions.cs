using My.AspNetCore.WebForms.Templating;
using System;
using WebFormsSampleCS.Templates;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class WebFormsServiceCollectionExtensions
    {
        public static IServiceCollection WithMustacheTemplate(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddOptions();
 
            // Get the registered ITemplate service from DI container
            var serviceProvider = services.BuildServiceProvider();
            var templatingService = serviceProvider.GetRequiredService<ITemplate>();
            var templatingServiceDescriptor = new ServiceDescriptor(typeof(ITemplate), templatingService);

            // Replace the ITemplate service with the new one
            services.Remove(templatingServiceDescriptor);
            services.AddSingleton<ITemplate, MustacheTemplate>();

            return services;
        }

        public static IServiceCollection WithRazorTemplate(this IServiceCollection services)
        {
            if (services == null)
            {
                throw new ArgumentNullException(nameof(services));
            }

            services.AddOptions();

            // Get the registered ITemplate service from DI container
            var serviceProvider = services.BuildServiceProvider();
            var templatingService = serviceProvider.GetRequiredService<ITemplate>();
            var templatingServiceDescriptor = new ServiceDescriptor(typeof(ITemplate), templatingService);

            // Replace the ITemplate service with the new one
            services.Remove(templatingServiceDescriptor);
            services.AddSingleton<ITemplate, RazorTemplate>();

            return services;
        }
    }
}
