using System;
using System.IO;
using System.Threading.Tasks;

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

        public async override Task RenderAsync(TextWriter writer)
        {
            await writer.WriteLineAsync($"<input name=\"{Name}\" type=\"submit\" value=\"{Text}\" />");
        }
    }
}
