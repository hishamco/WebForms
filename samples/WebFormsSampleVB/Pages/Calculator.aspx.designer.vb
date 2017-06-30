Namespace WebFormsSampleVB.Pages
    Partial Public Class Calculator
        Private txtNumber1 As Global.My.AspNetCore.WebForms.Controls.TextBox
        Private txtNumber2 As Global.My.AspNetCore.WebForms.Controls.TextBox
        Private btnAdd As Global.My.AspNetCore.WebForms.Controls.Button
        Private btnSub As Global.My.AspNetCore.WebForms.Controls.Button
        Private btnMul As Global.My.AspNetCore.WebForms.Controls.Button
        Private btnDiv As Global.My.AspNetCore.WebForms.Controls.Button
        Private litResult As Global.My.AspNetCore.WebForms.Controls.Literal

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
            AddHandler Me.btnAdd.Command, AddressOf Button_Command

            ' 
            ' btnSub
            ' 
            Me.btnSub.Name = "btnSub"
            Me.btnSub.CssClass = "btn btn-primary"
            Me.btnSub.Text = "Sub"
            Me.btnSub.CommandName = "Sub"
            AddHandler Me.btnSub.Command, AddressOf Button_Command

            ' 
            ' btnMul
            ' 
            Me.btnMul.Name = "btnMul"
            Me.btnMul.CssClass = "btn btn-primary"
            Me.btnMul.Text = "Mul"
            Me.btnMul.CommandName = "Mul"
            AddHandler Me.btnMul.Command, AddressOf Button_Command

            ' 
            ' btnDiv
            ' 
            Me.btnDiv.Name = "btnDiv"
            Me.btnDiv.CssClass = "btn btn-primary"
            Me.btnDiv.Text = "Div"
            Me.btnDiv.CommandName = "Div"
            AddHandler Me.btnDiv.Command, AddressOf Button_Command

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
