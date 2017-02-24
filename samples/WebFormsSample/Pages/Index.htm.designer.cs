namespace WebFormsSample.Pages
{
    public partial class Index
    {
        private global::My.AspNetCore.WebForms.Controls.Literal litGreeting;
        private global::My.AspNetCore.WebForms.Controls.Literal litPostBack;

        #region Web Form Designer generated code
        private void InitializeComponent()
        {
            litGreeting = new global::My.AspNetCore.WebForms.Controls.Literal();
            litPostBack = new global::My.AspNetCore.WebForms.Controls.Literal();

            // 
            // litGreeting
            // 
            this.litGreeting.Id = "litGreeting";

            // 
            // litPostBack
            // 
            this.litPostBack.Id = "litPostBack";
            this.litPostBack.Text = "IsPostBack: False";

            this.Load += Page_Load;
            this.Controls.Add(litGreeting);
            this.Controls.Add(litPostBack);
        }
        #endregion
    }
}
