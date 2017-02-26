using System.IO;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Controls
{
    public class TextBox : Control
    {
        public string Text { get; set; }

        public async override Task RenderAsync(TextWriter writer)
        {
            await writer.WriteLineAsync($"<input name=\"{Name}\" type=\"text\" value=\"{Text}\" />");
        }
    }
}
