namespace My.AspNetCore.WebForms.Controls
{
    public class TextBox : Control
    {
        public string Text { get; set; }

        public override void Render()
        {
            InnerHtml = $"<input name=\"{Id}\" type=\"text\" value=\"{Text}\" />";
        }
    }
}
