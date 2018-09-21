using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebFormsWebsite
{
    public class RootedPagesStartup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebForms();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();

            app.UseWebForms();
        }
    }
}
