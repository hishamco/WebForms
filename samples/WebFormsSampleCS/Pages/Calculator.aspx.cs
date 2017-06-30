using Microsoft.Extensions.Logging;
using My.AspNetCore.WebForms;
using My.AspNetCore.WebForms.Controls;
using System;

namespace WebFormsSampleCS.Pages
{
    public partial class Calculator : Page
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void Button_Command(object sender, CommandEventArgs e)
        {
            Logger.LogInformation($"The button named '{((Button)sender).Name}' is clicked.");

            var number1 = Convert.ToInt32(txtNumber1.Text);
            var number2 = Convert.ToInt32(txtNumber2.Text);
            double result = 0;

            switch (e.CommandName)
            {
                case "Add":
                    result = number1 + number2;
                    break;
                case "Sub":
                    result = number1 - number2;
                    break;
                case "Mul":
                    result = number1 * number2;
                    break;
                case "Div":
                    if (number2 == 0)
                    {
                        Logger.LogWarning($"The divide by zero isn't allowed.");
                        litResult.Text = $"The result is Unknown";
                        return;
                    }
                    result = number1 / number2;
                    break;
            }

            litResult.Text = $"The result is {result}";
        }
    }
}
