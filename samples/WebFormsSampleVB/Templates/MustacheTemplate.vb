Imports My.AspNetCore.WebForms.Templating

Namespace WebFormsSampleVB.Templates
    Public Class MustacheTemplate
        Inherits Template
        Public Overrides Function Parse(ByVal template As String, ByVal model As Object) As String
            Dim result = Nustache.Core.Render.StringToString(template,
                New With {.ApplicationName = "ASP.NET Core Web Forms", .Title = model.Title})

            Return result
        End Function
    End Class
End Namespace
