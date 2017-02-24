namespace My.AspNetCore.WebForms.Controls
{
    public class Literal : Control
    {
        public string Text { get; set; }

        public override void Render()
        {
            InnerHtml = Text;
        }
    }
}
