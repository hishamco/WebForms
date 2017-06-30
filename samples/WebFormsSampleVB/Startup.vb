Imports Microsoft.AspNetCore.Builder
Imports Microsoft.AspNetCore.Hosting
Imports Microsoft.Extensions.DependencyInjection
Imports Microsoft.Extensions.Logging

Namespace WebFormsSampleVB
    Public Class Startup
        Public Sub ConfigureServices(ByVal services As IServiceCollection)
            'services.AddWebForms(options => options.PagesLocation = "WebForms")
            services.AddWebForms().
                WithMustacheTemplate()
        End Sub

        Public Sub Configure(ByVal app As IApplicationBuilder, ByVal env As IHostingEnvironment, ByVal loggerFactory As ILoggerFactory)
            loggerFactory.AddConsole(LogLevel.Debug)

            If env.IsDevelopment() Then
                app.UseDeveloperExceptionPage()
            End If

            app.UseStaticFiles()

            app.UseWebForms()
        End Sub
    End Class
End Namespace
