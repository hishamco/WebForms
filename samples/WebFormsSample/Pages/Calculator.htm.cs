using My.AspNetCore.WebForms;
using System;

namespace WebFormsSample.Pages
{
    public partial class Calculator : Page
    {
        public Calculator()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var number1 = Convert.ToInt32(txtNumber1.Text);
            var number2 = Convert.ToInt32(txtNumber2.Text);
            var sum = number1 + number2;
            litResult.Text = $"The sum is {sum}";
        }
    }
}
