namespace WebFormsSampleCS
{
    public partial class Calculator
    {
        private global::My.AspNetCore.WebForms.Controls.TextBox txtNumber1;
        private global::My.AspNetCore.WebForms.Controls.TextBox txtNumber2;
        private global::My.AspNetCore.WebForms.Controls.Button btnAdd;
        private global::My.AspNetCore.WebForms.Controls.Button btnSub;
        private global::My.AspNetCore.WebForms.Controls.Button btnMul;
        private global::My.AspNetCore.WebForms.Controls.Button btnDiv;
        private global::My.AspNetCore.WebForms.Controls.Literal litResult;

        #region Web Form Designer generated code
        private void InitializeComponent()
        {
            txtNumber1 = new global::My.AspNetCore.WebForms.Controls.TextBox();
            txtNumber2 = new global::My.AspNetCore.WebForms.Controls.TextBox();
            btnAdd = new global::My.AspNetCore.WebForms.Controls.Button();
            btnSub = new global::My.AspNetCore.WebForms.Controls.Button();
            btnMul = new global::My.AspNetCore.WebForms.Controls.Button();
            btnDiv = new global::My.AspNetCore.WebForms.Controls.Button();
            litResult = new global::My.AspNetCore.WebForms.Controls.Literal();

            // 
            // txtNumber1
            // 
            this.txtNumber1.Name = "txtNumber1";
            this.txtNumber1.CssClass = "form-control";

            // 
            // txtNumber2
            // 
            this.txtNumber2.Name = "txtNumber2";
            this.txtNumber2.CssClass = "form-control";

            // 
            // btnAdd
            // 
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.CssClass = "btn btn-primary";
            this.btnAdd.Text = "Add";
            this.btnAdd.CommandName = "Add";
            this.btnAdd.Command += Button_Command;

            // 
            // btnSub
            // 
            this.btnSub.Name = "btnSub";
            this.btnSub.CssClass = "btn btn-primary";
            this.btnSub.Text = "Sub";
            this.btnSub.CommandName = "Sub";
            this.btnSub.Command += Button_Command;

            // 
            // btnMul
            // 
            this.btnMul.Name = "btnMul";
            this.btnMul.CssClass = "btn btn-primary";
            this.btnMul.Text = "Mul";
            this.btnMul.CommandName = "Mul";
            this.btnMul.Command += Button_Command;

            // 
            // btnDiv
            // 
            this.btnDiv.Name = "btnDiv";
            this.btnDiv.CssClass = "btn btn-primary";
            this.btnDiv.Text = "Div";
            this.btnDiv.CommandName = "Div";
            this.btnDiv.Command += Button_Command;

            // 
            // litResult
            // 
            this.litResult.Name = "litResult";

            this.Title = "Calculator";
            this.Controls.Add(txtNumber1);
            this.Controls.Add(txtNumber2);
            this.Controls.Add(btnAdd);
            this.Controls.Add(btnSub);
            this.Controls.Add(btnMul);
            this.Controls.Add(btnDiv);
            this.Controls.Add(litResult);
        }
        #endregion
    }
}
