namespace WebFormsSample.Pages
{
    public partial class Calculator
    {
        private global::My.AspNetCore.WebForms.Controls.TextBox txtNumber1;
        private global::My.AspNetCore.WebForms.Controls.TextBox txtNumber2;
        private global::My.AspNetCore.WebForms.Controls.Button btnAdd;
        private global::My.AspNetCore.WebForms.Controls.Literal litResult;

        #region Web Form Designer generated code
        private void InitializeComponent()
        {
            txtNumber1 = new global::My.AspNetCore.WebForms.Controls.TextBox();
            txtNumber2 = new global::My.AspNetCore.WebForms.Controls.TextBox();
            btnAdd = new global::My.AspNetCore.WebForms.Controls.Button();
            litResult = new global::My.AspNetCore.WebForms.Controls.Literal();

            // 
            // txtNumber1
            // 
            this.txtNumber1.Name = "txtNumber1";
            
            // 
            // txtNumber2
            // 
            this.txtNumber2.Name = "txtNumber2";

            // 
            // btnAdd
            // 
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += btnAdd_Click;

            // 
            // litResult
            // 
            this.litResult.Name = "litResult";

            this.Controls.Add(txtNumber1);
            this.Controls.Add(txtNumber2);
            this.Controls.Add(btnAdd);
            this.Controls.Add(litResult);
        }
        #endregion
    }
}
