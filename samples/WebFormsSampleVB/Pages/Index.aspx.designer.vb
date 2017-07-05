Namespace WebFormsSampleVB.Pages
    Partial Public Class Index
        Private WithEvents cbWebForms As Global.My.AspNetCore.WebForms.Controls.CheckBox
        Private WithEvents cbMVC As Global.My.AspNetCore.WebForms.Controls.CheckBox
        Private WithEvents rbCS As Global.My.AspNetCore.WebForms.Controls.RadioButton
        Private WithEvents rbFS As Global.My.AspNetCore.WebForms.Controls.RadioButton
        Private WithEvents rbVB As Global.My.AspNetCore.WebForms.Controls.RadioButton
        Private WithEvents litGreeting As Global.My.AspNetCore.WebForms.Controls.Literal
        Private WithEvents litPostBack As Global.My.AspNetCore.WebForms.Controls.Literal
        Private WithEvents btnPost As Global.My.AspNetCore.WebForms.Controls.Button

#Region "Web Form Designer generated code"
        Private Sub InitializeComponent()
            cbWebForms = New Global.My.AspNetCore.WebForms.Controls.CheckBox()
            cbMVC = New Global.My.AspNetCore.WebForms.Controls.CheckBox
            rbCS = New Global.My.AspNetCore.WebForms.Controls.RadioButton()
            rbFS = New Global.My.AspNetCore.WebForms.Controls.RadioButton()
            rbVB = New Global.My.AspNetCore.WebForms.Controls.RadioButton()
            litGreeting = New Global.My.AspNetCore.WebForms.Controls.Literal()
            litPostBack = New Global.My.AspNetCore.WebForms.Controls.Literal()
            btnPost = New Global.My.AspNetCore.WebForms.Controls.Button()

            ' 
            ' cbWebForms
            ' 
            Me.cbWebForms.Name = "cbWebForms"
            Me.cbWebForms.Text = "WebForms"
            Me.cbWebForms.AutoPostBack = True

            ' 
            ' cbMVC
            ' 
            Me.cbMVC.Name = "cbMVC"
            Me.cbMVC.Text = "MVC"
            Me.cbMVC.AutoPostBack = True

            ' 
            ' rbCS
            ' 
            Me.rbCS.Name = "rbCS"
            Me.rbCS.GroupName = "Languages"
            Me.rbCS.Text = "C#"
            Me.rbCS.AutoPostBack = True

            ' 
            ' rbFS
            ' 
            Me.rbFS.Name = "rbFS"
            Me.rbFS.GroupName = "Languages"
            Me.rbFS.Text = "F#"
            Me.rbFS.AutoPostBack = True

            ' 
            ' rbVB
            ' 
            Me.rbVB.Name = "rbVB"
            Me.rbVB.GroupName = "Languages"
            Me.rbVB.Text = "VB"
            Me.rbVB.AutoPostBack = True

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
            Me.Controls.Add(cbWebForms)
            Me.Controls.Add(cbMVC)
            Me.Controls.Add(rbCS)
            Me.Controls.Add(rbFS)
            Me.Controls.Add(rbVB)
            Me.Controls.Add(litGreeting)
            Me.Controls.Add(litPostBack)
            Me.Controls.Add(btnPost)
        End Sub
#End Region
    End Class
End Namespace
