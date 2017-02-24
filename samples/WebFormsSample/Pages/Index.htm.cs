using My.AspNetCore.WebForms;
using My.AspNetCore.WebForms.Controls;
using System;

namespace WebFormsSample.Pages
{
    public class Index : Page
    {
        private Literal litGreeting;
        private Literal litPostBack;

        public Index()
        {
            litGreeting = new Literal()
            {
                Id = "litGreeting"
            };

            litPostBack = new Literal()
            {
                Id = "litPostBack",
                Text = "IsPostBack: False"
            };

            this.Load += Page_Load;
            this.Controls.Add(litGreeting);
            this.Controls.Add(litPostBack);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            litGreeting.Text = $"Hello, World! The time on the server is {DateTime.Now}";

            if (IsPostBack)
            {
                litPostBack.Text = "IsPostBack: True";
            }
        }
    }
}
