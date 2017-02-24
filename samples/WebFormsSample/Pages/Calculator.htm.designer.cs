namespace WebFormsSample.Pages
{
    public partial class Calculator
    {
        private global::My.AspNetCore.WebForms.Controls.TextBox txtNumber1;
        private global::My.AspNetCore.WebForms.Controls.TextBox txtNumber2;
        private global::My.AspNetCore.WebForms.Controls.Button bntAdd;
        private global::My.AspNetCore.WebForms.Controls.Literal litResult;

        #region Web Form Designer generated code
        private void InitializeComponent()
        {
            txtNumber1 = new global::My.AspNetCore.WebForms.Controls.TextBox();
            txtNumber2 = new global::My.AspNetCore.WebForms.Controls.TextBox();
            bntAdd = new global::My.AspNetCore.WebForms.Controls.Button();
            litResult = new global::My.AspNetCore.WebForms.Controls.Literal();

            // 
            // txtNumber1
            // 
            this.txtNumber1.Id = "txtNumber1";
            
            // 
            // txtNumber2
            // 
            this.txtNumber2.Id = "txtNumber2";

            // 
            // btnAdd
            // 
            this.bntAdd.Id = "btnAdd";
            this.bntAdd.Text = "Add";
            this.bntAdd.Click += btnAdd_Click;

            // 
            // litResult
            // 
            this.litResult.Id = "litResult";

            this.Controls.Add(txtNumber1);
            this.Controls.Add(txtNumber2);
            this.Controls.Add(bntAdd);
            this.Controls.Add(litResult);
        }
        #endregion
    }
}
