using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using My.AspNetCore.WebForms;
using My.AspNetCore.WebForms.Templating;

namespace WebFormsSample
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebForms();
            // Remove the last added dependeny which is of sure of type 'ITemplate'
            services.RemoveAt(services.Count - 1);
            services.AddSingleton<ITemplate, SimpleTemplate>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseWebForms();
        }

        private class SimpleTemplate : Template
        {
            public override string Parse(string template, dynamic model)
            {
                // For the sake of the demo I'm looking for {{title}} only
                // but we can go further to evaluate all the public properties using Reflection 
                var page = (Page) model;
                var result = template.Replace("{{title}}", page.Title);

                return result;
            }
        }
    }
}
