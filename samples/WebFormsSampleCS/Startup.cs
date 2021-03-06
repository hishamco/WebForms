﻿using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace WebFormsSampleCS
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            //services.AddWebForms(options => options.PagesLocation = "WebForms");
            services.AddWebForms()
                .WithMustacheTemplate();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(LogLevel.Debug);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();

            app.UseWebForms();
        }
    }
}
