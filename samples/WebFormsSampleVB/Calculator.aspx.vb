Imports Microsoft.Extensions.Logging
Imports My.AspNetCore.WebForms
Imports My.AspNetCore.WebForms.Controls

Namespace WebFormsSampleVB
    Partial Public Class Calculator
        Inherits Page

        Public Sub New()
            InitializeComponent()
        End Sub

        Private Sub Button_Command(ByVal sender As Object, ByVal e As CommandEventArgs) Handles btnAdd.Command, btnSub.Command, btnMul.Command, btnDiv.Command
            Logger.LogInformation($"The button named '{CType(sender, Button).Name}' is clicked.")

            Dim number1 = Convert.ToInt32(txtNumber1.Text)
            Dim number2 = Convert.ToInt32(txtNumber2.Text)
            Dim result As Double = 0

            Select Case e.CommandName
                Case "Add"
                    result = number1 + number2
                Case "Sub"
                    result = number1 - number2
                Case "Mul"
                    result = number1 * number2
                Case "Div"
                    If number2 = 0 Then
                        Logger.LogWarning($"The divide by zero isn't allowed.")
                        litResult.Text = $"The result is Unknown"
                        Exit Sub
                    End If
                    result = number1 / number2
            End Select

            litResult.Text = $"The result is {result}"
        End Sub
    End Class
End Namespace
