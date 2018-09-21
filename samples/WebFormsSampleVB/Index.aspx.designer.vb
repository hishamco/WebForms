Imports My.AspNetCore.WebForms.Controls

Namespace WebFormsSampleVB
    Partial Public Class Index
        Private WithEvents cbWebForms As Global.My.AspNetCore.WebForms.Controls.CheckBox
        Private WithEvents cbMVC As Global.My.AspNetCore.WebForms.Controls.CheckBox
        Private WithEvents rbCS As Global.My.AspNetCore.WebForms.Controls.RadioButton
        Private WithEvents rbFS As Global.My.AspNetCore.WebForms.Controls.RadioButton
        Private WithEvents rbVB As Global.My.AspNetCore.WebForms.Controls.RadioButton
        Private WithEvents ddlGender As Global.My.AspNetCore.WebForms.Controls.DropDownList
        Private WithEvents litGreeting As Global.My.AspNetCore.WebForms.Controls.Literal
        Private WithEvents litPostBack As Global.My.AspNetCore.WebForms.Controls.Literal
        Private WithEvents btnPost As Global.My.AspNetCore.WebForms.Controls.Button
        Private hlText As Global.My.AspNetCore.WebForms.Controls.HyperLink
        Private hlImage As Global.My.AspNetCore.WebForms.Controls.HyperLink
        Private imgLogo As Global.My.AspNetCore.WebForms.Controls.Image

#Region "Web Form Designer generated code"
        Private Sub InitializeComponent()
            cbWebForms = New Global.My.AspNetCore.WebForms.Controls.CheckBox()
            cbMVC = New Global.My.AspNetCore.WebForms.Controls.CheckBox
            rbCS = New Global.My.AspNetCore.WebForms.Controls.RadioButton()
            rbFS = New Global.My.AspNetCore.WebForms.Controls.RadioButton()
            rbVB = New Global.My.AspNetCore.WebForms.Controls.RadioButton()
            ddlGender = New Global.My.AspNetCore.WebForms.Controls.DropDownList()
            litGreeting = New Global.My.AspNetCore.WebForms.Controls.Literal()
            litPostBack = New Global.My.AspNetCore.WebForms.Controls.Literal()
            btnPost = New Global.My.AspNetCore.WebForms.Controls.Button()
            hlText = New Global.My.AspNetCore.WebForms.Controls.HyperLink()
            hlImage = New Global.My.AspNetCore.WebForms.Controls.HyperLink()
            imgLogo = New Global.My.AspNetCore.WebForms.Controls.Image()

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
            ' ddlGender
            ' 
            Me.ddlGender.Name = "ddlGender"
            Me.ddlGender.AutoPostBack = True
            Me.ddlGender.Items = New List(Of ListItem) From {
                New ListItem("Male"),
                New ListItem("Female")
            }

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

            ' 
            ' hlText
            ' 
            Me.hlText.Name = "hlText"
            Me.hlText.NavigationUrl = "https://github.com/"
            Me.hlText.Text = "GitHub"

            ' 
            ' hlImage
            ' 
            Me.hlImage.Name = "hlImage"
            Me.hlImage.NavigationUrl = "https://github.com/"
            Me.hlImage.ImageUrl = "Images/github-logo.png"
            Me.hlImage.ImageHeight = 50
            Me.hlImage.ImageWidth = 50

            ' 
            ' imgLogo
            ' 
            Me.imgLogo.Name = "imgLogo"
            Me.imgLogo.ImageUrl = "Images/github-logo.png"
            Me.imgLogo.AlternateText = "GitHub"
            Me.imgLogo.ImageAlign = ImageAlign.Left

            Me.Title = "Home"
            Me.Controls.Add(cbWebForms)
            Me.Controls.Add(cbMVC)
            Me.Controls.Add(rbCS)
            Me.Controls.Add(rbFS)
            Me.Controls.Add(rbVB)
            Me.Controls.Add(ddlGender)
            Me.Controls.Add(litGreeting)
            Me.Controls.Add(litPostBack)
            Me.Controls.Add(btnPost)
            Me.Controls.Add(hlText)
            Me.Controls.Add(hlImage)
            Me.Controls.Add(imgLogo)
        End Sub
#End Region
    End Class
End Namespace
