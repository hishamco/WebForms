using My.AspNetCore.WebForms.Controls;
using System.Collections.Generic;

namespace WebFormsSampleCS
{
    public partial class Index
    {
        private global::My.AspNetCore.WebForms.Controls.CheckBox cbWebForms;
        private global::My.AspNetCore.WebForms.Controls.CheckBox cbMVC;
        private global::My.AspNetCore.WebForms.Controls.RadioButton rbCS;
        private global::My.AspNetCore.WebForms.Controls.RadioButton rbFS;
        private global::My.AspNetCore.WebForms.Controls.RadioButton rbVB;
        private global::My.AspNetCore.WebForms.Controls.DropDownList ddlGender;
        private global::My.AspNetCore.WebForms.Controls.Literal litGreeting;
        private global::My.AspNetCore.WebForms.Controls.Literal litPostBack;
        private global::My.AspNetCore.WebForms.Controls.Button btnPost;

        #region Web Form Designer generated code
        private void InitializeComponent()
        {
            cbWebForms = new global::My.AspNetCore.WebForms.Controls.CheckBox();
            cbMVC = new global::My.AspNetCore.WebForms.Controls.CheckBox();
            rbCS = new global::My.AspNetCore.WebForms.Controls.RadioButton();
            rbFS = new global::My.AspNetCore.WebForms.Controls.RadioButton();
            rbVB = new global::My.AspNetCore.WebForms.Controls.RadioButton();
            ddlGender = new global::My.AspNetCore.WebForms.Controls.DropDownList();
            litGreeting = new global::My.AspNetCore.WebForms.Controls.Literal();
            litPostBack = new global::My.AspNetCore.WebForms.Controls.Literal();
            btnPost = new global::My.AspNetCore.WebForms.Controls.Button();

            // 
            // cbWebForms
            // 
            this.cbWebForms.Name = "cbWebForms";
            this.cbWebForms.Text = "WebForms";
            this.cbWebForms.AutoPostBack = true;

            // 
            // cbMVC
            // 
            this.cbMVC.Name = "cbMVC";
            this.cbMVC.Text = "MVC";
            this.cbMVC.AutoPostBack = true;

            // 
            // rbCS
            // 
            this.rbCS.Name = "rbCS";
            this.rbCS.GroupName = "Languages";
            this.rbCS.Text = "C#";
            this.rbCS.AutoPostBack = true;

            // 
            // rbFS
            // 
            this.rbFS.Name = "rbFS";
            this.rbFS.GroupName = "Languages";
            this.rbFS.Text = "F#";
            this.rbFS.AutoPostBack = true;

            // 
            // rbVB
            // 
            this.rbVB.Name = "rbVB";
            this.rbVB.GroupName = "Languages";
            this.rbVB.Text = "VB";
            this.rbVB.AutoPostBack = true;

            // 
            // ddlGender
            // 
            this.ddlGender.Name = "ddlGender";
            this.ddlGender.AutoPostBack = true;
            this.ddlGender.Items = new List<ListItem>
            {
                new ListItem("Male"),
                new ListItem("Female")
            };

            // 
            // litGreeting
            // 
            this.litGreeting.Name = "litGreeting";

            // 
            // litPostBack
            // 
            this.litPostBack.Name = "litPostBack";
            this.litPostBack.Text = "IsPostBack: False";

            // 
            // btnPost
            // 
            this.btnPost.Name = "btnPost";
            this.btnPost.Text = "Post";
            this.btnPost.CssClass = "btn btn-primary";

            this.Title = "Home";
            this.Load += Page_Load;
            this.Controls.Add(cbWebForms);
            this.Controls.Add(cbMVC);
            this.Controls.Add(rbCS);
            this.Controls.Add(rbFS);
            this.Controls.Add(rbVB);
            this.Controls.Add(ddlGender);
            this.Controls.Add(litGreeting);
            this.Controls.Add(litPostBack);
            this.Controls.Add(btnPost);
        }
        #endregion
    }
}
