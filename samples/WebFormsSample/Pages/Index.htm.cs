using My.AspNetCore.WebForms;
using My.AspNetCore.WebForms.Controls;
using System;

namespace WebFormsSample.Pages
{
    public class Index : Page
    {
        private Literal litGreeting;

        public Index()
        {
            litGreeting = new Literal()
            {
                Id = "litGreeting"
            };
            this.Load += Page_Load;
            this.Controls.Add(litGreeting);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            litGreeting.Text = $"Hello, World! The time on the server is {DateTime.Now}";
        }
    }
}
