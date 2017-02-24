using System;

namespace My.AspNetCore.WebForms.Controls
{
    public class Button : Control
    {
        public event EventHandler Click;

        public string Text { get; set; }

        protected virtual void OnClick()
        {
            Click?.Invoke(this, EventArgs.Empty);
        }

        public override void Render()
        {
            InnerHtml = $"<input name=\"{Id}\" type=\"submit\" value=\"{Text}\" />";
        }
    }
}
