Namespace WebFormsSampleVB.Pages
    Partial Public Class Index
        Private litGreeting As Global.My.AspNetCore.WebForms.Controls.Literal
        Private litPostBack As Global.My.AspNetCore.WebForms.Controls.Literal
        Private btnPost As Global.My.AspNetCore.WebForms.Controls.Button

#Region "Web Form Designer generated code"
        Private Sub InitializeComponent()
            litGreeting = New Global.My.AspNetCore.WebForms.Controls.Literal()
            litPostBack = New Global.My.AspNetCore.WebForms.Controls.Literal()
            btnPost = New Global.My.AspNetCore.WebForms.Controls.Button()

            ' 
            ' litGreeting
            ' 
            Me.litGreeting.Name = "litGreeting"

            ' 
            ' litPostBack
            ' 
            Me.litPostBack.Name = "litPostBack"
            Me.litPostBack.Text = "IsPostBack: False"

            ' 
            ' btnPost
            ' 
            Me.btnPost.Name = "btnPost"
            Me.btnPost.Text = "Post"
            Me.btnPost.CssClass = "btn btn-primary"

            Me.Title = "Home"
            AddHandler Me.Load, AddressOf Page_Load
            Me.Controls.Add(litGreeting)
            Me.Controls.Add(litPostBack)
            Me.Controls.Add(btnPost)
        End Sub
#End Region
    End Class
End Namespace
