Imports Microsoft.AspNetCore.Hosting
Imports My.AspNetCore.WebForms.Templating
Imports RazorLight
Imports RazorLight.Extensions

Namespace WebFormsSampleVB.Templates
    Public Class RazorTemplate
        Inherits Template
        Private _hostingEnvironment As IHostingEnvironment

        Public Sub New(ByVal hostingEnvironment As IHostingEnvironment)
            _hostingEnvironment = hostingEnvironment
        End Sub

        Public Overrides Function Parse(ByVal template As String, ByVal model As Object) As String
            Dim root = _hostingEnvironment.WebRootPath
            Dim engine = EngineFactory.CreatePhysical(root)
            Dim result = engine.ParseString(template,
                New With {.ApplicationName = "ASP.NET Core Web Forms", .Title = model.Title})

            Return result
        End Function
    End Class
End Namespace
