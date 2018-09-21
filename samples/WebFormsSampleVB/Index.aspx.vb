Imports Microsoft.Extensions.Logging
Imports My.AspNetCore.WebForms
Imports System

Namespace WebFormsSampleVB
    Partial Public Class Index
        Inherits Page

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Page_Load(ByVal sender As Object, ByVal e As PageLoadEventArgs) Handles Me.Load
            Logger.LogInformation($"The page titled '{Title}' is loaded.")

            litGreeting.Text = $"Hello, World! The time on the server is {DateTime.Now}"

            If e.IsPostBack Then
                litPostBack.Text = "IsPostBack: True"
            End If
        End Sub
    End Class
End Namespace
