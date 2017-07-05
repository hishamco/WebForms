Namespace WebFormsSampleVB.Pages
    Partial Public Class Calculator
        Private WithEvents txtNumber1 As Global.My.AspNetCore.WebForms.Controls.TextBox
        Private WithEvents txtNumber2 As Global.My.AspNetCore.WebForms.Controls.TextBox
        Private WithEvents btnAdd As Global.My.AspNetCore.WebForms.Controls.Button
        Private WithEvents btnSub As Global.My.AspNetCore.WebForms.Controls.Button
        Private WithEvents btnMul As Global.My.AspNetCore.WebForms.Controls.Button
        Private WithEvents btnDiv As Global.My.AspNetCore.WebForms.Controls.Button
        Private WithEvents litResult As Global.My.AspNetCore.WebForms.Controls.Literal

#Region "Web Form Designer generated code"
        Private Sub InitializeComponent()
            txtNumber1 = New Global.My.AspNetCore.WebForms.Controls.TextBox()
            txtNumber2 = New Global.My.AspNetCore.WebForms.Controls.TextBox()
            btnAdd = New Global.My.AspNetCore.WebForms.Controls.Button()
            btnSub = New Global.My.AspNetCore.WebForms.Controls.Button()
            btnMul = New Global.My.AspNetCore.WebForms.Controls.Button()
            btnDiv = New Global.My.AspNetCore.WebForms.Controls.Button()
            litResult = New Global.My.AspNetCore.WebForms.Controls.Literal()

            ' 
            ' txtNumber1
            ' 
            Me.txtNumber1.Name = "txtNumber1"
            Me.txtNumber1.CssClass = "form-control"

            ' 
            ' txtNumber2
            ' 
            Me.txtNumber2.Name = "txtNumber2"
            Me.txtNumber2.CssClass = "form-control"

            ' 
            ' btnAdd
            ' 
            Me.btnAdd.Name = "btnAdd"
            Me.btnAdd.CssClass = "btn btn-primary"
            Me.btnAdd.Text = "Add"
            Me.btnAdd.CommandName = "Add"

            ' 
            ' btnSub
            ' 
            Me.btnSub.Name = "btnSub"
            Me.btnSub.CssClass = "btn btn-primary"
            Me.btnSub.Text = "Sub"
            Me.btnSub.CommandName = "Sub"

            ' 
            ' btnMul
            ' 
            Me.btnMul.Name = "btnMul"
            Me.btnMul.CssClass = "btn btn-primary"
            Me.btnMul.Text = "Mul"
            Me.btnMul.CommandName = "Mul"

            ' 
            ' btnDiv
            ' 
            Me.btnDiv.Name = "btnDiv"
            Me.btnDiv.CssClass = "btn btn-primary"
            Me.btnDiv.Text = "Div"
            Me.btnDiv.CommandName = "Div"

            ' 
            ' litResult
            ' 
            Me.litResult.Name = "litResult"

            Me.Title = "Calculator"
            Me.Controls.Add(txtNumber1)
            Me.Controls.Add(txtNumber2)
            Me.Controls.Add(btnAdd)
            Me.Controls.Add(btnSub)
            Me.Controls.Add(btnMul)
            Me.Controls.Add(btnDiv)
            Me.Controls.Add(litResult)
        End Sub
#End Region
    End Class
End Namespace
