namespace WebFormsSample.Pages
{
    public partial class Index
    {
        private global::My.AspNetCore.WebForms.Controls.Literal litGreeting;
        private global::My.AspNetCore.WebForms.Controls.Literal litPostBack;
        private global::My.AspNetCore.WebForms.Controls.Button btnPost;

        #region Web Form Designer generated code
        private void InitializeComponent()
        {
            litGreeting = new global::My.AspNetCore.WebForms.Controls.Literal();
            litPostBack = new global::My.AspNetCore.WebForms.Controls.Literal();
            btnPost = new global::My.AspNetCore.WebForms.Controls.Button();

            // 
            // litGreeting
            // 
            this.litGreeting.Id = "litGreeting";

            // 
            // litPostBack
            // 
            this.litPostBack.Id = "litPostBack";
            this.litPostBack.Text = "IsPostBack: False";

            // 
            // btnPost
            // 
            this.btnPost.Id = "btnPost";
            this.btnPost.Text = "Post";

            this.Load += Page_Load;
            this.Controls.Add(litGreeting);
            this.Controls.Add(litPostBack);
            this.Controls.Add(btnPost);
        }
        #endregion
    }
}
