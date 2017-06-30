Imports My.AspNetCore.WebForms.Templating
Imports System
Imports System.Runtime.CompilerServices
Imports WebFormsSampleVB.Templates

Namespace Microsoft.Extensions.DependencyInjection
    Public Module WebFormsServiceCollectionExtensions
        <Extension()>
        Public Function WithMustacheTemplate(ByVal services As IServiceCollection) As IServiceCollection
            If services Is Nothing Then
                Throw New ArgumentNullException(NameOf(services))
            End If

            services.AddOptions()

            ' Get the registered ITemplate service from DI container
            Dim serviceProvider = services.BuildServiceProvider()
            Dim templatingService = serviceProvider.GetRequiredService(Of ITemplate)()
            Dim templatingServiceDescriptor = New ServiceDescriptor(GetType(ITemplate), templatingService)

            ' Replace the ITemplate service with the New one
            services.Remove(templatingServiceDescriptor)
            services.AddSingleton(Of ITemplate, MustacheTemplate)()

            Return services
        End Function

        <Extension()>
        Public Function WithRazorTemplate(ByVal services As IServiceCollection) As IServiceCollection
            If services Is Nothing Then
                Throw New ArgumentNullException(NameOf(services))
            End If

            services.AddOptions()

            ' Get the registered ITemplate service from DI container
            Dim serviceProvider = services.BuildServiceProvider()
            Dim templatingService = serviceProvider.GetRequiredService(Of ITemplate)()
            Dim templatingServiceDescriptor = New ServiceDescriptor(GetType(ITemplate), templatingService)

            ' Replace the ITemplate service with the New one
            services.Remove(templatingServiceDescriptor)
            services.AddSingleton(Of ITemplate, RazorTemplate)()

            Return services
        End Function
    End Module
End Namespace
