using My.AspNetCore.WebForms;
using System;

namespace WebFormsSample.Pages
{
    public partial class Index : Page
    {
        public Index()
        {
            InitializeComponent();
        }

        private void Page_Load(object sender, PageLoadEventArgs e)
        {
            litGreeting.Text = $"Hello, World! The time on the server is {DateTime.Now}";

            if (e.IsPostBack)
            {
                litPostBack.Text = "IsPostBack: True";
            }
        }
    }
}
