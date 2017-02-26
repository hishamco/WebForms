using System.IO;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace My.AspNetCore.WebForms.Controls
{
    public class Literal : Control
    {
        public string Text { get; set; }

        public bool Encoded { get; set; } = true;

        public async override Task RenderAsync(TextWriter writer)
        {
            if (Text?.Length > 0)
            {
                if (Encoded)
                {
                    Text = HtmlEncoder.Default.Encode(Text);
                }

                await writer.WriteAsync(Text);
            }
        }
    }
}
